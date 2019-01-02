/*  JetiBackup - A Backup tool for Jeti Transmitters.
 *  Copyright (C) 2018-2019 - Stefan Seifert
 *
 *  JetiBackup is free software: you can redistribute it and/or modify it under the terms
 *  of the GNU General Public License as published by the Free Software Found-
 *  ation, either version 3 of the License, or (at your option) any later version.
 *
 *  RetroArch is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR
 *  PURPOSE.  See the GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along with RetroArch.
 *  If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace JetiBackup
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Management;
    using System.Runtime.Serialization.Json;
    using log4net;
    using LibGit2Sharp;

    internal class JetiBackup
    {
        public delegate void BackupEventHandler(object sender, string sourcePath, string destinationPath, string type);

        private const string Filename = "Configuration.json";
        private static readonly ILog log = LogManager.GetLogger(typeof (JetiBackupDialog));

        private readonly ManagementEventWatcher watcher;

        public JetiBackup()
        {
            watcher = new ManagementEventWatcher();

            if (File.Exists(Filename)) {
                using (FileStream fs = File.Open(Filename, FileMode.Open)) {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof (Configuration));
                    Configuration = jsonSerializer.ReadObject(fs) as Configuration;
                }
            }

            if (Configuration == null) {
                Configuration = new Configuration();
            }
        }

        public Configuration Configuration { get; set; }
        
        public event BackupEventHandler BackupStartEvent;
        public event BackupEventHandler BackupFinishedEvent;

        public void Start()
        {
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            watcher.EventArrived += watcher_EventArrived;
            watcher.Query = query;
            watcher.Start();
        }

        private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            WatcherStartBackup();
        }

        private string GetSdPath()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo driveInfo in drives) {
                try
                {
                    if (driveInfo.VolumeLabel == Configuration.JetiDriveName)
                    {
                        return driveInfo.RootDirectory.FullName;
                    }
                }catch (Exception ex)
                {
                    log.Error("Failed to get VolumeLabel", ex);
                }
            }

            return null;
        }

        public void SaveConfiguration()
        {
            using (FileStream fs = File.Open(Filename, FileMode.Create)) {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof (Configuration));
                jsonSerializer.WriteObject(fs, Configuration);
            }
        }

        public void Stop()
        {
            watcher.Stop();
        }

        public void FullBackup()
        {
            string backupPath = Path.Combine(Configuration.BackupDirectory, Configuration.FullBackupFolder);
            string sourcePath = GetSdPath();

            if (sourcePath == null)
                return;

            switch (Configuration.FullBackupMode) {
                case BackupMode.Git:
                    StartGitBackup(sourcePath, backupPath, "Full");
                    break;
                case BackupMode.DatedDirectories:
                    if (sourcePath != null)
                        InitDirectoryBackup(sourcePath, backupPath, "Full", false);

                    Configuration.LastFullBackup = DateTime.Now;
                    SaveConfiguration();
                    break;
                case BackupMode.Differential:
                    if (!string.IsNullOrEmpty(sourcePath))
                        InitDirectoryBackup(sourcePath, backupPath, "Full", true);

                    Configuration.LastFullBackup = DateTime.Now;
                    SaveConfiguration();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ModelBackup()
        {
            string backupPath = Path.Combine(Configuration.BackupDirectory, Configuration.ModelFolder);
            string sourcePath = GetSdPath();

            if (sourcePath == null)
                return;

            sourcePath = Path.Combine(sourcePath, "Model");

            switch (Configuration.ModelBackupMode) {
                case BackupMode.Git:
                    StartGitBackup(Path.Combine(sourcePath, "Model"), backupPath, "Model");

                    break;
                case BackupMode.DatedDirectories:
                    if (!string.IsNullOrEmpty(sourcePath))
                        InitDirectoryBackup(sourcePath, backupPath, "Model", false);

                    Configuration.LastModelBackup = DateTime.Now;
                    SaveConfiguration();
                    break;
                case BackupMode.Differential:
                    if (!string.IsNullOrEmpty(sourcePath))
                        InitDirectoryBackup(sourcePath, backupPath, "Model", true);

                    Configuration.LastModelBackup = DateTime.Now;
                    SaveConfiguration();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void StartGitBackup(string sourcePath, string backupPath, string backupType)
        {
            if (log.IsDebugEnabled)
                log.Info(string.Format("Start git backup ({2}) from {0} to {1}", sourcePath, backupPath, backupType));

            if (BackupStartEvent != null)
                BackupStartEvent(this, sourcePath, backupPath, "Git Backup");

            bool newSync = false;

            if (!Repository.IsValid(backupPath))
            {
                Repository.Init(backupPath);
                newSync = true;
            }
            
            if (InitGitBackup(sourcePath, backupPath, backupType) || newSync)
            {
                using (var repo = new Repository(backupPath))
                {
                    Signature author =
                        new Signature("Jeti Backup", "JetiBackup@codechaos.org", DateTimeOffset.Now);

                    Commands.Stage(repo, "*");

                    repo.Commit(string.Format("Jeti {1} Backup {0}", DateTime.Now, backupType), author, author,
                        new CommitOptions());
                }
            }

            if (BackupFinishedEvent != null)
                BackupFinishedEvent(this, sourcePath, backupPath, "Git Backup");

            if (log.IsDebugEnabled)
                log.Info(string.Format("Finished git backup ({2}) from {0} to {1}", sourcePath, backupPath, backupType));
        }

        public void LogBackup()
        {
            string sourcePath = GetSdPath();

            if (sourcePath == null)
                return;

            sourcePath = Path.Combine(sourcePath, "Log");
            string backupPath = Path.Combine(Configuration.BackupDirectory, Configuration.LogFolder);

            if (string.IsNullOrEmpty(sourcePath))
            {
                log.Error("LogBackup failed - Sourcepath is empty.");
                return;
            }

            if (string.IsNullOrEmpty(backupPath))
            {
                log.Error("LogBackup failed - Destinationpath is empty.");
                return;
            }

            if (!Directory.Exists(sourcePath) || !Directory.Exists(backupPath))
            {
                log.Error(string.Format("LogBackup failed - Source: \"{0}\" or Destination: \"{1}\" does no exist.", sourcePath, backupPath));
                return;
            }

            switch (Configuration.LogBackupMode) {
                case BackupMode.Git:
                    StartGitBackup(sourcePath, backupPath, "Log");

                    break;
                case BackupMode.DatedDirectories:
                    InitDirectoryBackup(sourcePath, backupPath, "Log", false);

                    Configuration.LastLogBackup = DateTime.Now;
                    SaveConfiguration();
                    break;
                case BackupMode.Differential:
                    InitDirectoryBackup(sourcePath, backupPath, "Log", true);

                    Configuration.LastLogBackup = DateTime.Now;
                    SaveConfiguration();
                    break;
            }
        }

        private void WatcherStartBackup()
        {
            if (log.IsDebugEnabled)
                log.Debug("Jeti drive connected (watcher).");

            if (CheckBackupNecessary(Configuration.LastFullBackup, Configuration.FullBackupFrequency)) {
                FullBackup();
            }

            if (CheckBackupNecessary(Configuration.LastModelBackup, Configuration.ModelBackupFrequency)) {
                ModelBackup();
            }

            if (CheckBackupNecessary(Configuration.LastLogBackup, Configuration.LogBackupFrequency))
            {
                LogBackup();
            }
        }

        private void InitDirectoryBackup(string sourcePath, string destinationPath, string type, bool inkrementalCopy)
        {
            if (!Directory.Exists(sourcePath))
                return;

            if (inkrementalCopy) {
                destinationPath = Path.Combine(destinationPath, string.Format("{0}", type));
            }
            else {
                destinationPath = Path.Combine(destinationPath,
                    string.Format("{0}-{1:yyyy-MM-dd_hh-mm-ss}", type, DateTime.Now));
            }

            if (BackupStartEvent != null)
                BackupStartEvent(this, sourcePath, destinationPath, type);

            if (log.IsDebugEnabled)
                log.Info(string.Format("Start backup from {0} to {1}", sourcePath, destinationPath));

            Directory.CreateDirectory(destinationPath);

            CopyRecursive(new DirectoryInfo(sourcePath), new DirectoryInfo(destinationPath), inkrementalCopy);

            if (BackupFinishedEvent != null)
                BackupFinishedEvent(this, sourcePath, destinationPath, type);

            if (log.IsDebugEnabled)
                log.Info(string.Format("Finished backup from {0} to {1}", sourcePath, destinationPath));
        }

        private bool InitGitBackup(string sourcePath, string destinationPath, string backupType)
        {
            if (!Directory.Exists(sourcePath))
                return false;

            bool filesSynced = SyncRecursive(new DirectoryInfo(sourcePath), new DirectoryInfo(destinationPath));
            
            return filesSynced;
        }

        private bool SyncRecursive(DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory)
        {
            bool changes = false;

            foreach (FileInfo sourceFileInfo in sourceDirectory.GetFiles()) {
                FileInfo destinationFile = new FileInfo(Path.Combine(destinationDirectory.FullName, sourceFileInfo.Name));

                if (!destinationFile.Exists || sourceFileInfo.LastWriteTime > destinationFile.LastWriteTime) {
                    sourceFileInfo.CopyTo(destinationFile.FullName, true);
                    changes = true;
                }
            }

            foreach (FileInfo files in destinationDirectory.GetFiles().Except(sourceDirectory.GetFiles(), new FileCompare()))
            {
                files.Delete();
                changes = true;
            }

            foreach (DirectoryInfo currentDirectory in sourceDirectory.GetDirectories())
            {
                if ((currentDirectory.Attributes & FileAttributes.System) == FileAttributes.System)
                {
                    continue;
                }

                string newSynPath = Path.Combine(destinationDirectory.FullName, currentDirectory.Name);

                if (log.IsDebugEnabled)
                    log.Debug(string.Format("Creating directory: {0}", newSynPath));
                Directory.CreateDirectory(newSynPath);
                changes = true;
                SyncRecursive(currentDirectory, new DirectoryInfo(newSynPath));
            }

             
            foreach (DirectoryInfo directoryInfo in destinationDirectory.GetDirectories().Except(sourceDirectory.GetDirectories(), new DirectoryCompare())) {
                if (directoryInfo.Name == ".git")
                    continue;

                directoryInfo.Delete(true);
                changes = true;
            }

            return changes;
        }

        private void CopyRecursive(DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory, bool inkremental)
        {
            bool overwrite = false;

            foreach (FileInfo sourceFile in sourceDirectory.GetFiles()) {
                FileInfo destinationFile = new FileInfo(Path.Combine(destinationDirectory.FullName, sourceFile.Name));
                overwrite = false;

                if (inkremental) {
                    if (destinationFile.Exists) {
                        if (sourceFile.LastWriteTime > destinationFile.LastWriteTime) {
                            overwrite = true;
                        }
                        else {
                            continue;
                        }
                    }
                }

                if (log.IsDebugEnabled)
                    log.Debug(string.Format("Copying: {0} to {1}", sourceFile.FullName, destinationFile.FullName));

                sourceFile.CopyTo(destinationFile.FullName, overwrite);
            }

            foreach (DirectoryInfo currentDirectory in sourceDirectory.GetDirectories()) {
                if ((currentDirectory.Attributes & FileAttributes.System) == FileAttributes.System) {
                    continue;
                }

                string backupPath = Path.Combine(destinationDirectory.FullName, currentDirectory.Name);

                if (log.IsDebugEnabled)
                    log.Debug(string.Format("Creating directory: {0}", backupPath));
                Directory.CreateDirectory(backupPath);

                CopyRecursive(currentDirectory, new DirectoryInfo(backupPath), inkremental);
            }
        }

        private bool CheckBackupNecessary(DateTime lastBackup, BackupFrequency backupFrequency)
        {
            if (log.IsDebugEnabled)
                log.Debug(string.Format("Backup necessary - Current Date: {0} Backup Frequency: {1}", DateTime.Now,
                    backupFrequency));
            bool backupNecessary = false;
            GregorianCalendar cal;

            switch (backupFrequency) {
                case BackupFrequency.OnConnect:
                    backupNecessary = true;
                    break;
                case BackupFrequency.Daily:
                    backupNecessary = lastBackup < DateTime.Today;
                    break;
                case BackupFrequency.Weekly:
                    cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
                    return cal.GetWeekOfYear(lastBackup, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) < cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                case BackupFrequency.Monthly:
                    cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
                    backupNecessary = cal.GetMonth(lastBackup) < cal.GetMonth(DateTime.Now);
                    break;

                case BackupFrequency.Never:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(backupFrequency), backupFrequency, null);
            }

            return backupNecessary;
        }
        

        public bool CheckForDriveNameCollision(string drivename)
        {
            bool collision = true;

            int counter = 0;
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives()) {
                try
                {
                    if (driveInfo.VolumeLabel == drivename)
                    {
                        counter++;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Failed to get VolumeLabel", ex);
                }
            }

            if (counter == 1) {
                collision = false;
            }

            if (log.IsDebugEnabled && collision) {
                log.Debug(string.Format("Drivename collision: {0}", drivename));
            }
            return collision;
        }


        public string LastFullBackup()
        {
            return Configuration.LastFullBackup.ToString();
        }

        public string LastModelBackup()
        {
            return Configuration.LastModelBackup.ToString();
        }
        

        private delegate bool Del(DateTime date);
    }
}

class DirectoryCompare : System.Collections.Generic.IEqualityComparer<System.IO.DirectoryInfo>
{
    public DirectoryCompare() { }

    public bool Equals(System.IO.DirectoryInfo f1, System.IO.DirectoryInfo f2)
    {
        return (f1.Name == f2.Name);
    }

    public int GetHashCode(System.IO.DirectoryInfo fi)
    {
        string s = String.Format("{0}", fi.Name);
        return s.GetHashCode();
    }
}

class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
{
    public FileCompare() { }

    public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
    {
        return (f1.Name == f2.Name &&
                f1.Length == f2.Length);
    }

    public int GetHashCode(System.IO.FileInfo fi)
    {
        string s = String.Format("{0}{1}", fi.Name, fi.Length);
        return s.GetHashCode();
    }
}
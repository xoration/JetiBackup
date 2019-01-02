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

namespace JetiBackup
{
    using System;

    public class Configuration
    {
        private string jetiDrive;
        private string backupDirectory;
        private string modelFolder;
        private string fullBackupFolter;
        private string logFolder;

        
        private BackupMode sdBackupMode;
        private BackupFrequency sdBackupFrequency;
        private BackupMode modelBackupMode;
        private BackupFrequency modelBackupFrequency;
        private BackupMode logBackupMode;
        private BackupFrequency logBackupFrequency;

        private DateTime lastFullBackup;
        private DateTime lastModelBackup;
        private DateTime lastLogBackup;


        public Configuration()
        {
            jetiDrive = string.Empty;
            backupDirectory = string.Empty;
            modelFolder = "ModelBackup";
            fullBackupFolter = "SDBackup";
            logFolder = "LogBackup";

            sdBackupMode = BackupMode.DatedDirectories;
            sdBackupFrequency = BackupFrequency.OnConnect;
            modelBackupMode = BackupMode.DatedDirectories;
            modelBackupFrequency = BackupFrequency.OnConnect;
            logBackupMode = BackupMode.DatedDirectories;
            logBackupFrequency = BackupFrequency.OnConnect;

            lastFullBackup = DateTime.MinValue.ToUniversalTime();
            lastModelBackup = DateTime.MinValue.ToUniversalTime();
            lastLogBackup = DateTime.MinValue.ToUniversalTime();
        }

        public string JetiDriveName
        {
            get { return jetiDrive; }
            set { jetiDrive = value; }
        }

        public string BackupDirectory
        {
            get { return backupDirectory; }
            set { backupDirectory = value; }
        }

        public BackupMode FullBackupMode
        {
            get { return sdBackupMode; }
            set { sdBackupMode = value; }
        }


        public BackupFrequency FullBackupFrequency
        {
            get { return sdBackupFrequency; }
            set { sdBackupFrequency = value; }
        }


        public string ModelFolder
        {
            get { return modelFolder; }
            set { modelFolder = value; }
        }


        public string FullBackupFolder
        {
            get { return fullBackupFolter; }
            set { fullBackupFolter = value; }
        }


        public string LogFolder
        {
            get { return logFolder; }
            set { logFolder = value; }
        }

        public BackupMode ModelBackupMode
        {
            get { return modelBackupMode; }
            set { modelBackupMode = value; }
        }

        public BackupFrequency ModelBackupFrequency
        {
            get { return modelBackupFrequency; }
            set { modelBackupFrequency = value; }
        }
        
        public BackupMode LogBackupMode
        {
            get { return logBackupMode; }
            set { logBackupMode = value; }
        }

        public BackupFrequency LogBackupFrequency
        {
            get { return logBackupFrequency; }
            set { logBackupFrequency = value; }
        }

        public DateTime LastFullBackup
        {
            get { return lastFullBackup; }
            set { lastFullBackup = value; }
        }

        public DateTime LastModelBackup
        {
            get { return lastModelBackup; }
            set { lastModelBackup = value; }
        }

        public DateTime LastLogBackup
        {
            get { return lastLogBackup; }
            set { lastLogBackup = value; }
        }
    }
}

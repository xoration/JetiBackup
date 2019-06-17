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
    using System.IO;
    using System.Windows.Forms;
    using log4net;


    public partial class JetiBackupDialog : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(JetiBackupDialog));

        private readonly JetiBackup Backup;
        private string version;

        private bool allowVisible;
        private BindingSource jetiDriveBindingSource;
        private BindingSource modelBackupFolderBindingSource;
        private BindingSource fullBackupFolderBindingSource;
        private BindingSource logBackupFolderBindingSource;
        private BindingSource sdBackupDirectoryBindingSource;
        private BindingSource modelFolderBindingSource;
        private BindingSource logFolderBindingSource;

        public JetiBackupDialog()
        {
            Backup = new JetiBackup();
            Version softwareVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            version = String.Format("Jeti Backup {0}.{1}", softwareVersion.Major, softwareVersion.Minor);

            InitializeComponent();

            InitBindings();
            InitEvents();
        }

        private void InitBindings()
        {
            cb_sdBackupMode.DataSource = Enum.GetValues(typeof(BackupMode));
            cb_sdBackupMode.SelectedItem = Backup.Configuration.FullBackupMode;
            cb_sdBackupFrequency.DataSource = Enum.GetValues(typeof(BackupFrequency));
            cb_sdBackupFrequency.SelectedItem = Backup.Configuration.FullBackupFrequency;

            cb_modelBackupMode.DataSource = Enum.GetValues(typeof(BackupMode));
            cb_modelBackupMode.SelectedItem = Backup.Configuration.ModelBackupMode;
            cb_modelBackupFrequency.DataSource = Enum.GetValues(typeof(BackupFrequency));
            cb_modelBackupFrequency.SelectedItem = Backup.Configuration.ModelBackupFrequency;

            cb_logBackupMode.DataSource = Enum.GetValues(typeof(BackupMode));
            cb_logBackupMode.SelectedItem = Backup.Configuration.LogBackupMode;
            cb_logBackupFrequency.DataSource = Enum.GetValues(typeof(BackupFrequency));
            cb_logBackupFrequency.SelectedItem = Backup.Configuration.LogBackupFrequency;

            jetiDriveBindingSource = new BindingSource();
            jetiDriveBindingSource.DataSource = Backup.Configuration;
            txt_jetiDrive.DataBindings.Add("Text", jetiDriveBindingSource, "JetiDriveName");

            sdBackupDirectoryBindingSource = new BindingSource();
            sdBackupDirectoryBindingSource.DataSource = Backup.Configuration;
            txt_backupDirectory.DataBindings.Add("Text", sdBackupDirectoryBindingSource, "BackupDirectory");

            modelBackupFolderBindingSource = new BindingSource();
            modelBackupFolderBindingSource.DataSource = Backup.Configuration;
            txt_modelBackupFolder.DataBindings.Add("Text", modelBackupFolderBindingSource, "BackupModelFolder");

            fullBackupFolderBindingSource = new BindingSource();
            fullBackupFolderBindingSource.DataSource = Backup.Configuration;
            txt_sdBackupFolder.DataBindings.Add("Text", fullBackupFolderBindingSource, "FullBackupFolder");

            logBackupFolderBindingSource = new BindingSource();
            logBackupFolderBindingSource.DataSource = Backup.Configuration;
            txt_logBackupFolder.DataBindings.Add("Text", logBackupFolderBindingSource, "BackupLogFolder");

            modelFolderBindingSource = new BindingSource();
            modelFolderBindingSource.DataSource = Backup.Configuration;
            txtModelFolder.DataBindings.Add("Text", modelFolderBindingSource, "SdCardModelFolder");

            modelFolderBindingSource = new BindingSource();
            modelFolderBindingSource.DataSource = Backup.Configuration;
            txtLogFolder.DataBindings.Add("Text", modelFolderBindingSource, "SdCardLogFolder");
        }

        private void InitEvents()
        {
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += OnResize;
            btn_jetiDrive.Click += BtnJetiDriveOnClick;
            btn_sdBackupDir.Click += BtnSDBackupDirOnClick;
            btn_fullBackup.Click += BtnBackupNowOnClick;
            btn_modelBackup.Click += BtnModelBackupOnClick;
            btn_logBackup.Click += BtnLogBackupOnClick;
            notifyIcon.DoubleClick += ShowDialogOnClick;
            Backup.BackupStartEvent += BackupOnBackupStartEvent;
            Backup.BackupFinishedEvent += BackupOnBackupFinishedEvent;
            modelBackupToolStripMenuItem.Click += BtnModelBackupOnClick;
            fullBackupToolStripMenuItem.Click += BtnBackupNowOnClick;
            configureToolStripMenuItem.Click += ShowDialogOnClick;
            exitToolStripMenuItem.Click += ExitToolStripMenuItemOnClick;

            cb_sdBackupFrequency.SelectedIndexChanged += delegate
            {
                Backup.Configuration.FullBackupFrequency =
                    (BackupFrequency)cb_sdBackupFrequency.SelectedItem;
                Backup.SaveConfiguration();
            };

            cb_sdBackupMode.SelectedIndexChanged += delegate
            {
                Backup.Configuration.FullBackupMode =
                    (BackupMode)cb_sdBackupMode.SelectedItem;
                Backup.SaveConfiguration();
            };

            cb_modelBackupFrequency.SelectedIndexChanged += delegate
            {
                Backup.Configuration.ModelBackupFrequency =
                    (BackupFrequency)
                    cb_modelBackupFrequency.SelectedItem;
                Backup.SaveConfiguration();
            };

            cb_modelBackupMode.SelectedIndexChanged += delegate
            {
                Backup.Configuration.ModelBackupMode =
                    (BackupMode)cb_modelBackupMode.SelectedItem;
                Backup.SaveConfiguration();
            };

            cb_logBackupMode.SelectedIndexChanged += delegate (object sender, EventArgs args)
            {
                Backup.Configuration.LogBackupMode = (BackupMode)cb_logBackupMode.SelectedItem;
                Backup.SaveConfiguration();
            };

            cb_logBackupFrequency.SelectedIndexChanged += delegate (object sender, EventArgs args)
            {
                    Backup.Configuration.LogBackupFrequency = (BackupFrequency)cb_logBackupFrequency.SelectedItem;
                    Backup.SaveConfiguration();
            };
        }

        private void BtnLogBackupOnClick(object o, EventArgs eventArgs)
        {
            Backup.LogBackup();
        }

        private void OnResize(object sender, EventArgs eventArgs)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                allowVisible = false;
                Show();
            }
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        private void ExitToolStripMenuItemOnClick(object sender, EventArgs eventArgs)
        {
            Close();
        }


        private void BackupOnBackupStartEvent(object sender, string sourcePath, string destinationPath, string type)
        {
            backupRunningPictureBox.Visible = true;
            notifyIcon.BalloonTipTitle = "Jeti Backup";
            notifyIcon.BalloonTipText = string.Format("{0} backup started...", type);
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.ShowBalloonTip(2);
            notifyIcon.Text = string.Format("{0} backup running...", type);
        }

        private void BackupOnBackupFinishedEvent(object sender, string sourcePath, string destinationPath, string type)
        {
            backupRunningPictureBox.Visible = false;
            notifyIcon.BalloonTipTitle = "Jeti Backup";
            notifyIcon.BalloonTipText = string.Format("{0} backup finished...", type);
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.ShowBalloonTip(2);
            notifyIcon.Text = version;
        }


        private void BtnModelBackupOnClick(object sender, EventArgs e)
        {
            Backup.ModelBackup();
            lbl_lastModelBackup.Text = Backup.LastModelBackup();
        }

        private void ShowDialogOnClick(object sender, EventArgs eventArgs)
        {
            allowVisible = true;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void BtnBackupNowOnClick(object sender, EventArgs eventArgs)
        {
            Backup.FullBackup();
            lbl_lastFullBackup.Text = Backup.LastFullBackup();
        }

        private void BtnSDBackupDirOnClick(object sender, EventArgs eventArgs)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            if (folderBrowserDialog.SelectedPath != string.Empty)
            {
                string path = folderBrowserDialog.SelectedPath;

                DirectoryInfo fullBackupDirectory = new DirectoryInfo(path);
                DriveInfo driveInfo = new DriveInfo(fullBackupDirectory.Root.Name);

                if (driveInfo.VolumeLabel != Backup.Configuration.JetiDriveName)
                {
                    Backup.Configuration.BackupDirectory = folderBrowserDialog.SelectedPath;
                    sdBackupDirectoryBindingSource.ResetBindings(true);

                    Backup.SaveConfiguration();
                }
                else
                {
                    MessageBox.Show("Error: Backup directory cannot be on the Jeti Drive!", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void BtnJetiDriveOnClick(object sender, EventArgs eventArgs)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            if (folderBrowserDialog.SelectedPath != string.Empty)
            {
                foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
                {
                    if (driveInfo.Name == folderBrowserDialog.SelectedPath && driveInfo.IsReady)
                    {
                        if (!Backup.CheckForDriveNameCollision(driveInfo.VolumeLabel))
                        {
                            Backup.Configuration.JetiDriveName = driveInfo.VolumeLabel;
                        }
                        else
                        {
                            Backup.Configuration.JetiDriveName = string.Empty;
                            MessageBox.Show("Error: Jeti Drivename has to be unique!", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            if (log.IsDebugEnabled)
                                log.Debug(string.Format("Jeti Drivename is not unqiue: {0}", driveInfo.VolumeLabel));
                        }
                        break;
                    }

                    if (driveInfo.IsReady)
                    {
                        log.Error("Drive is not read.");
                    }
                }

                jetiDriveBindingSource.ResetBindings(true);

                Backup.SaveConfiguration();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Backup.Start();
            lbl_lastFullBackup.Text = Backup.LastFullBackup();
            lbl_lastModelBackup.Text = Backup.LastModelBackup();

            this.Text = version;
            this.notifyIcon.Text = version;

            WindowState = FormWindowState.Minimized;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Backup.SaveConfiguration();
            Backup.Stop();
        }
    }
}
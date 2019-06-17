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
        public Configuration()
        {
            JetiDriveName = string.Empty;
            BackupDirectory = string.Empty;
            BackupModelFolder = "ModelBackup";
            FullBackupFolder = "SDBackup";
            BackupLogFolder = "LogBackup";
            SdCardModelFolder = "Model";
            SdCardLogFolder = "Log";

            FullBackupMode = BackupMode.DatedDirectories;
            FullBackupFrequency = BackupFrequency.OnConnect;
            ModelBackupMode = BackupMode.DatedDirectories;
            ModelBackupFrequency = BackupFrequency.OnConnect;
            LogBackupMode = BackupMode.DatedDirectories;
            LogBackupFrequency = BackupFrequency.OnConnect;

            LastFullBackup = DateTime.MinValue.ToUniversalTime();
            LastModelBackup = DateTime.MinValue.ToUniversalTime();
            LastLogBackup = DateTime.MinValue.ToUniversalTime();
        }

        public string JetiDriveName { get; set; }

        public string BackupDirectory { get; set; }

        public BackupMode FullBackupMode { get; set; }


        public BackupFrequency FullBackupFrequency { get; set; }


        public string BackupModelFolder { get; set; }

        public string FullBackupFolder { get; set; }

        public string BackupLogFolder { get; set; }

        public string SdCardModelFolder { get; set; }

        public string SdCardLogFolder { get; set; }

        public BackupMode ModelBackupMode { get; set; }

        public BackupFrequency ModelBackupFrequency { get; set; }

        public BackupMode LogBackupMode { get; set; }

        public BackupFrequency LogBackupFrequency { get; set; }

        public DateTime LastFullBackup { get; set; }

        public DateTime LastModelBackup { get; set; }

        public DateTime LastLogBackup { get; set; }
    }
}

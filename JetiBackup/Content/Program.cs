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
    using System.Windows.Forms;
    using log4net;
    using log4net.Config;

    static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(JetiBackupDialog));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure();

            if (log.IsDebugEnabled) {
                log.Debug("Starting Jeti Backup.");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new JetiBackupDialog());

            if (log.IsDebugEnabled) {
                log.Debug("Exiting  Jeti Backup.");
            }
        }
    }
}

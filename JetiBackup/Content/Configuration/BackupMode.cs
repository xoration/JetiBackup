﻿/*  JetiBackup - A Backup tool for Jeti Transmitters.
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
    public enum BackupMode : int
    {
        Git = 1,
        DatedDirectories = 0,
        Differential = 2
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace ZabbixAgentInstaller.Common
{
    public class DiskHelper
    {
        public static String[] GetAllDiskName()
        {
            // GetDrives : 检索计算机上的所有逻辑驱动器的驱动器名称。
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            return allDrives.Where(d => d.IsReady).Select(drive => drive.Name).ToArray();
        }

    }
}

using System;
using System.Text;

namespace TinTin {
  /*  System.Environment.OSVersion
+-----------------------------------------------------------------------------------------------------------------------------------------+
|           |   Windows    |   Windows    |   Windows    |Windows NT| Windows | Windows | Windows | Windows | Windows | Windows | Windows |
|           |     95       |      98      |     Me       |    4.0   |  2000   |   XP    |  2003   |  Vista  |  2008   |    7    | 2008 R2 |
+-----------------------------------------------------------------------------------------------------------------------------------------+
|PlatformID | Win32Windows | Win32Windows | Win32Windows | Win32NT  | Win32NT | Win32NT | Win32NT | Win32NT | Win32NT | Win32NT | Win32NT |
+-----------------------------------------------------------------------------------------------------------------------------------------+
|Major      |              |              |              |          |         |         |         |         |         |         |         |
| version   |      4       |      4       |      4       |    4     |    5    |    5    |    5    |    6    |    6    |    6    |    6    |
+-----------------------------------------------------------------------------------------------------------------------------------------+
|Minor      |              |              |              |          |         |         |         |         |         |         |         |
| version   |      0       |     10       |     90       |    0     |    0    |    1    |    2    |    0    |    0    |    1    |    1    |
+-----------------------------------------------------------------------------------------------------------------------------------------+
   */
  internal static class Platform {
    public static string OSInfo() {
      var sb = new StringBuilder(String.Empty);

      sb.AppendLine("Operation System Information");
      sb.AppendLine("----------------------------");
      sb.AppendLine(String.Format("Name = {0}", OSVersionInfo.Name));
      sb.AppendLine(String.Format("Edition = {0}", OSVersionInfo.Edition));
      sb.AppendLine(OSVersionInfo.ServicePack != string.Empty ? String.Format("Service Pack = {0}", OSVersionInfo.ServicePack) : "Service Pack = None");
      sb.AppendLine(String.Format("Version = {0}", OSVersionInfo.VersionString));
      sb.AppendLine(String.Format("ProcessorBits = {0}", OSVersionInfo.ProcessorBits));
      sb.AppendLine(String.Format("OSBits = {0}", OSVersionInfo.OSBits));
      sb.AppendLine(String.Format("ProgramBits = {0}", OSVersionInfo.ProgramBits));

      return sb.ToString();  
    }

    public static bool IsLinux {
      get {
        var p = (int) Environment.OSVersion.Platform;
        return (p == 4) || (p == 6) || (p == 128);
      }
    }

    public static bool IsWindows {
      get {
        return IsWin95 | IsWin98 | IsWinME | IsWinNT | IsWin2000 | IsWinXP | IsWin2003 | IsWinVista | IsWin2008 | IsWin7 | IsWin2008R2 | IsWin2008 | IsWin8_1;
      }
    }

    public static bool IsWin95 {
      get {
        var p = (int) Environment.OSVersion.Platform;
        return (p == 4) || (p == 6) || (p == 128);
      }
    }

    public static bool IsWin98 {
      get {
        var p = (int) Environment.OSVersion.Platform;
        return (p == 4) || (p == 6) || (p == 128);
      }
    }
  }
}
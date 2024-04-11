//  *****************************************************************************
//  File:       Platform.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;

namespace TinTin {
  /*  System.Environment.OSVersion
+-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+
|           |   Windows    |    Windows   |   Windows    |   Windows    |   Windows    |Windows NT| Windows | Windows | Windows | Windows     | Windows | Windows | Windows | Windows | Windows R1  | Windows | Windows R2  | Windows | Windows     |   Windows   |
|           |     3.1      |     3.11     |     95       |      98      |     Me       |    4.0   |  2000   |   XP    | XP-64   | 2003 (R1&2) |  Vista  |  2008   |    7    | 2008 R2 | Server 2012 |    8    | Server 2012 |  8.1    | Server 2016 |     10      |
+-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+
|PlatformID |    Win32S    |    Win32S    | Win32Windows | Win32Windows | Win32Windows | Win32NT  | Win32NT | Win32NT | Win32NT |   Win32NT   | Win32NT | Win32NT | Win32NT | Win32NT |  Win32NT    | Win32NT |   Win32NT   | Win32NT |  Win32NT    |  Win32NT    |
+-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+
|Major      |              |              |              |              |              |          |         |         |         |             |         |         |         |         |             |         |             |         |             |             |
| version   |      3       |       3      |      4       |      4       |      4       |    4     |    5    |    5    |    5    |    5        |    6    |    6    |    6    |    6    |    6        |    6    |      6      |    6    |    10       |      10     |
+-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+
|Minor      |              |              |              |              |              |          |         |         |         |             |         |         |         |         |             |         |             |         |             |             |
| version   |      1       |       11     |      0       |     10       |     90       |    0     |    0    |    1    |    2    |    2        |    0    |    0    |    1    |    1    |    2        |    2    |      3      |    3    |     0       |       0     |
+-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+
   */

  internal static class Platform {
    public static bool IsLinux {
      get {
        var p = Environment.OSVersion.Platform;
        return p == PlatformID.Unix || p == PlatformID.MacOSX;
      }
    }

    public static bool IsWindows => IsWin3_1 | IsWin3_11 | IsWin95 | IsWin98 | IsWinME | IsWinNT | IsWin2000 | IsWinXP | IsWinXP_64 | IsWin2003 | IsWinVista | IsWin2008 | IsWin7 | IsWin2008R2 | IsWin2012R1 | IsWin8 |
                                    IsWin2012R2 | IsWin8_1 | IsWin2016 | IsWin10;

    // ReSharper disable InconsistentNaming
    public static bool IsWin3_1 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 3 && ver.Minor == 1;
      }
    }

    public static bool IsWin3_11 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 3 && ver.Minor == 11;
      }
    }

    public static bool IsWin95 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 4 && ver.Minor == 0;
      }
    }

    public static bool IsWinNT {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 4 && ver.Minor == 0;
      }
    }

    public static bool IsWin98 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 4 && ver.Minor == 10;
      }
    }

    public static bool IsWinME {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 4 && ver.Minor == 90;
      }
    }

    public static bool IsWin2000 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 5 && ver.Minor == 0;
      }
    }

    public static bool IsWinXP {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 5 && ver.Minor == 1;
      }
    }

    public static bool IsWin2003 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 5 && ver.Minor == 2;
      }
    }

    public static bool IsWinXP_64 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 5 && ver.Minor == 2;
      }
    }

    public static bool IsWinVista {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 6 && ver.Minor == 0;
      }
    }

    public static bool IsWin2008 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 6 && ver.Minor == 0;
      }
    }

    public static bool IsWin7 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 6 && ver.Minor == 1;
      }
    }

    public static bool IsWin2008R2 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 6 && ver.Minor == 1;
      }
    }

    public static bool IsWin8 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 6 && ver.Minor == 2;
      }
    }

    public static bool IsWin2012R1 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 6 && ver.Minor == 2;
      }
    }

    public static bool IsWin8_1 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 6 && ver.Minor == 3;
      }
    }

    public static bool IsWin2012R2 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 6 && ver.Minor == 3;
      }
    }

    public static bool IsWin2016 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 10 && ver.Minor == 0;
      }
    }

    public static bool IsWin10 {
      get {
        var ver = Environment.OSVersion.Version;
        return ver.Major == 10 && ver.Minor == 0;
      }
    }

    // ReSharper restore InconsistentNaming
  }
}
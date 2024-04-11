//  *****************************************************************************
//  File:      NativeStructs.cs
//  Solution:  Sentinel
//  Project:   Common
//  Date:      07/14/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System;
using System.Runtime.InteropServices;

namespace TinTin.GUI.Common {
  public class NativeStructs {
    /// <summary>
    ///  Native keyboard DLL hook structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct KBDLLHOOKSTRUCT {
      public readonly uint vkCode; // Keys
      public readonly uint scanCode;
      public readonly uint flags;
      public readonly uint time;
      public readonly UIntPtr dwExtraInfo;
    }


    /// <summary>
    ///  Rectangle
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct RECT {
      public int Left;
      public int Top;
      public int Right;
      public int Bottom;
    }


    /// <summary>
    ///  DOCHOSTUIINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct DOCHOSTUIINFO {
      public int cbSize;
      public int dwFlags;
      public int dwDoubleClick;
      public IntPtr dwReserved1;
      public IntPtr dwReserved2;
    }


    /// <summary>
    ///  COMRECT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct COMRECT {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }


    /// <summary>
    ///  POINT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public class POINT {
      public int x;
      public int y;
    }


    /// <summary>
    ///  MINMAXINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct MINMAXINFO {
      public POINT ptReserved;
      public POINT ptMaxSize;
      public POINT ptMaxPosition;
      public POINT ptMinTrackSize;
      public POINT ptMaxTrackSize;
    }



    /// <summary>
    ///  Size of a device name string
    /// </summary>
    // ReSharper disable once InconsistentNaming
    private const int CCHDEVICENAME = 32;

    /// <summary>
    /// The MONITORINFOEX structure contains information about a display monitor.
    /// The GetMonitorInfo function stores information into a MONITORINFOEX structure or a MONITORINFO structure.
    /// The MONITORINFOEX structure is a superset of the MONITORINFO structure. The MONITORINFOEX structure adds a string member to contain a name 
    /// for the display monitor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct MonitorInfoEx {
      /// <summary>
      /// The size, in bytes, of the structure. Set this member to sizeof(MONITORINFOEX) (72) before calling the GetMonitorInfo function. 
      /// Doing so lets the function determine the type of structure you are passing to it.
      /// </summary>
      public int Size;

      /// <summary>
      /// A RECT structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates. 
      /// Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
      /// </summary>
      public RECT Monitor;

      /// <summary>
      /// A RECT structure that specifies the work area rectangle of the display monitor that can be used by applications, 
      /// expressed in virtual-screen coordinates. Windows uses this rectangle to maximize an application on the monitor. 
      /// The rest of the area in rcMonitor contains system windows such as the task bar and side bars. 
      /// Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
      /// </summary>
      public RECT WorkArea;

      /// <summary>
      /// The attributes of the display monitor.
      /// 
      /// This member can be the following value:
      ///   1 : MONITORINFOF_PRIMARY
      /// </summary>
      public uint Flags;

      /// <summary>
      /// A string that specifies the device name of the monitor being used. Most applications have no use for a display monitor name, 
      /// and so can save some bytes by using a MONITORINFO structure.
      /// </summary>
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
      public string DeviceName;

      public void Init() {
        Size = 40 + 2 * CCHDEVICENAME;
        DeviceName = string.Empty;
      }
    }
  }
}
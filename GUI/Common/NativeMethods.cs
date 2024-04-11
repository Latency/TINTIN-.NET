//  *****************************************************************************
//  File:      NativeMethods.cs
//  Solution:  Sentinel
//  Project:   Common
//  Date:      07/22/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System;
using System.Windows;
using System.Windows.Interop;

namespace TinTin.GUI.Common {
  public static class NativeMethods {
    public static void CustomMenu(object sender) {
      if (!(sender is Window window))
        throw new NullReferenceException(nameof(window));

      // See https://msdn.microsoft.com/en-us/library/windows/desktop/ms632600(v=vs.85).aspx
      // ReSharper disable InconsistentNaming
      const int GWL_STYLE = -16;
      const int GWL_EXSTYLE = -20;

      // ReSharper restore InconsistentNaming
      var hwnd = new WindowInteropHelper(window).Handle;

      var value = (uint) NativeStubs.GetWindowLong(hwnd, GWL_STYLE);
      value |= (uint) WindowStyles.WS_SYSMENU;  // Required for WS_EX_CONTEXTHELP
#if (DEBUG || NOLOCKDOWN)
      value &= (uint) ~WindowStyles.WS_MAXIMIZEBOX;
#endif
      NativeStubs.SetWindowLong(hwnd, GWL_STYLE, (int) (value & (uint) ~WindowStyles.WS_MINIMIZEBOX));

      // If WS_MAXIMIZEBOX is specified, the WS_EX_CONTEXTHELP will be overriden.
      value = (uint) NativeStubs.GetWindowLong(hwnd, GWL_EXSTYLE);
      NativeStubs.SetWindowLong(hwnd, GWL_EXSTYLE, (int) (value | (uint) WindowStyles.WS_EX_CONTEXTHELP));
    }


    /// <summary>
    ///  WmGetMinMaxInfo
    /// </summary>
    /// <param name="hwnd"></param>
    /// <param name="lParam"></param>
    public static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam) {
      var mmi = (NativeStructs.MINMAXINFO)System.Runtime.InteropServices.Marshal.PtrToStructure(lParam, typeof(NativeStructs.MINMAXINFO));

      /*  0x0001        // center rect to monitor 
          0x0000        // clip rect to monitor 
          0x0002        // use monitor work area 
          0x0000        // use monitor entire area */

      // ReSharper disable once InconsistentNaming
      const int MONITOR_DEFAULTTONEAREST = 0x00000002;
      var monitor = NativeStubs.MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

      if (monitor != IntPtr.Zero) {
        var monitorInfo = new NativeStructs.MonitorInfoEx();
        NativeStubs.GetMonitorInfo(monitor, ref monitorInfo);
        var rcWorkArea = monitorInfo.WorkArea;
        var rcMonitorArea = monitorInfo.Monitor;

        // set the maximize size of the application
        mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.Left - rcMonitorArea.Left);
        mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.Top - rcMonitorArea.Top);
        mmi.ptMaxSize.x = Math.Abs(rcWorkArea.Right - rcWorkArea.Left);
        mmi.ptMaxSize.y = Math.Abs(rcWorkArea.Bottom - rcWorkArea.Top);

        // reset the bounds of the application to the monitor working dimensions
        mmi.ptMaxTrackSize.x = mmi.ptMaxSize.x;
        mmi.ptMaxTrackSize.y = mmi.ptMaxSize.y;
      }

      System.Runtime.InteropServices.Marshal.StructureToPtr(mmi, lParam, true);
    }
  }
}
//  *****************************************************************************
//  File:      NativeDelegates.cs
//  Solution:  Sentinel
//  Project:   Common
//  Date:      07/14/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System;

namespace TinTin.GUI.Common {
  /// <summary>
  ///   Delegate for KBDLLHOOKSTRUCT
  /// </summary>
  /// <param name="nCode"></param>
  /// <param name="wParam"></param>
  /// <param name="lParam"></param>
  /// <returns></returns>
  public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, ref NativeStructs.KBDLLHOOKSTRUCT lParam);

  /// <summary>
  ///   Callback delegate for the
  ///   <see cref="NativeStubs.EnumDisplayMonitors" /> function.
  /// </summary>
  /// <param name="hMonitor">The handle of the monitor.</param>
  /// <param name="hdcMonitor">The handle of the GDI device context for the monitor.</param>
  /// <param name="lprcMonitor">The virtual coordinates for the monitor.</param>
  /// <param name="dwData">
  ///   Optional data value that was passed to the
  ///   <see cref="NativeStubs.EnumDisplayMonitors" /> function.
  /// </param>
  /// <returns>
  ///   Returns 1 to continue the enumeration, or 0 to stop the enumeration.
  /// </returns>
  public delegate int MonitorEnumProc(IntPtr hMonitor, IntPtr hdcMonitor, IntPtr lprcMonitor, IntPtr dwData);
}
//  *****************************************************************************
//  File:      NativeStubs.cs
//  Solution:  Sentinel
//  Project:   Common
//  Date:      07/14/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TinTin.GUI.Common {
  /// <summary>
  ///   Defines P/Invoke interop methods.
  /// </summary>
  internal static class NativeStubs {
    /// <summary>
    ///  SetWindowPos
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="hWndInsertAfter"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="cx"></param>
    /// <param name="cy"></param>
    /// <param name="wFlags"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

    /// <summary>
    ///  GetWindowRect
    /// </summary>
    /// <param name="hwnd"></param>
    /// <param name="lpRect"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern bool GetWindowRect(HandleRef hwnd, out NativeStructs.RECT lpRect);

    /// <summary>
    ///  MonitorFromWindow
    /// </summary>
    /// <param name="hwnd"></param>
    /// <param name="dwFlags"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

    /// <summary>
    ///  GetMonitorInfo
    /// </summary>
    /// <param name="hMonitor"></param>
    /// <param name="lpmi"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern bool GetMonitorInfo(IntPtr hMonitor, ref NativeStructs.MonitorInfoEx lpmi);

    /// <summary>
    ///  GetClientRect
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="lpRect"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern bool GetClientRect(IntPtr hWnd, out NativeStructs.RECT lpRect);

    /// <summary>
    ///  ShowWindow
    /// </summary>
    /// <param name="hwnd"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern int ShowWindow(IntPtr hwnd, int command);

    /// <summary>
    ///  FindWindowEx
    /// </summary>
    /// <param name="hwndParent"></param>
    /// <param name="hwndChildAfter"></param>
    /// <param name="lpszClass"></param>
    /// <param name="lpszWindow"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    /// <summary>
    ///  GetDesktopWindow
    /// </summary>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern IntPtr GetDesktopWindow();
    
    /// <summary>
    ///  GetWindowLong
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="nIndex"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    /// <summary>
    ///  SetWindowLong
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="nIndex"></param>
    /// <param name="dwNewLong"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    /// <summary>
    /// </summary>
    /// <param name="lpClassName"></param>
    /// <param name="lpWindowName"></param>
    /// <returns></returns>
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    /// <summary>
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="msg"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

    /// <summary>
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="msg"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    ///   Enumerates through the display monitors that are connected to
    ///   the system.
    /// </summary>
    /// <param name="hdc">The GDI device context.</param>
    /// <param name="lprcClip">The clipping bounds.</param>
    /// <param name="lpfnEnum">A <see cref="MonitorEnumProc" /> delegate.</param>
    /// <param name="dwData">Optional state data to pass to the delegate.</param>
    /// <returns>
    ///   Returns true if the operation completed successfully.
    /// </returns>
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumProc lpfnEnum, IntPtr dwData);

    /// <summary>
    ///   Used to disable Aero functionality on Windows 7
    /// </summary>
    [DllImport("dwmapi.dll", EntryPoint = "DwmEnableComposition")]
    internal static extern uint Win32DwmEnableComposition(uint uCompositionAction);

    /// <summary>
    ///   Gets the description of a capture device driver.
    /// </summary>
    /// <param name="wDriverIndex">The index of the driver, between 0 and 9.</param>
    /// <param name="lpszName">The driver's name.</param>
    /// <param name="cbName">The maximum length of the driver name.</param>
    /// <param name="lpszVer">The description of the capture driver.</param>
    /// <param name="cbVer">The maximum length of the description.</param>
    /// <returns>
    ///   Returns true on success or false on failure.
    /// </returns>
    [DllImport("avicap32.dll", EntryPoint = "capGetDriverDescriptionW", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetDriverDescription(short wDriverIndex, StringBuilder lpszName, int cbName, StringBuilder lpszVer, int cbVer);

    /// <summary>
    ///   Open an existing thread object.
    /// </summary>
    /// <param name="desiredAccess">The access to the thread object.</param>
    /// <param name="inheritHandle">Inherit handle.</param>
    /// <param name="threadId">Thread id.</param>
    /// <returns>
    ///   The pointer
    /// </returns>
    [DllImport("kernel32.dll")]
    internal static extern IntPtr OpenThread(int desiredAccess, bool inheritHandle, uint threadId);

    /// <summary>
    ///   Suspend Thread.
    /// </summary>
    /// <param name="thread">The thread</param>
    /// <returns>
    ///   Result of the call
    /// </returns>
    [DllImport("kernel32.dll")]
    internal static extern uint SuspendThread(IntPtr thread);

    /// <summary>
    ///   Resume Thread
    /// </summary>
    /// <param name="thread">The thread</param>
    /// <returns>
    ///   Result of the call
    /// </returns>
    [DllImport("kernel32.dll")]
    internal static extern int ResumeThread(IntPtr thread);

    /// <summary>
    ///   CloseHandle
    /// </summary>
    /// <param name="hObject"></param>
    /// <returns></returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern bool CloseHandle(IntPtr hObject);

    /// <summary>
    ///   Deletes the object.
    /// </summary>
    /// <param name="hObject">The object.</param>
    /// <returns></returns>
    [DllImport("gdi32.dll")]
    internal static extern bool DeleteObject(IntPtr hObject);

    /// <summary>
    ///   ToAscii
    /// </summary>
    /// <param name="uVirtKey"></param>
    /// <param name="uScanCode"></param>
    /// <param name="lpbKeyState"></param>
    /// <param name="lpChar"></param>
    /// <param name="uFlags"></param>
    /// <returns></returns>
    [DllImport("User32.dll")]
    internal static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpChar, int uFlags);

    /// <summary>
    ///   ToUnicodeEx
    /// </summary>
    /// <param name="wVirtKey"></param>
    /// <param name="wScanCode"></param>
    /// <param name="lpKeyState"></param>
    /// <param name="pwszBuff"></param>
    /// <param name="cchBuff"></param>
    /// <param name="wFlags"></param>
    /// <param name="dwhkl"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);

    /// <summary>
    ///   GetForegroundWindow
    /// </summary>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern IntPtr GetForegroundWindow();

    /// <summary>
    ///   GetWindowThreadProcessId
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="lpdwProcessId"></param>
    /// <returns></returns>
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    /// <summary>
    ///  GetKeyboardLayout
    /// </summary>
    /// <param name="idThread"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern IntPtr GetKeyboardLayout(uint idThread);

    /// <summary>
    ///   GetKeyboardState
    /// </summary>
    /// <param name="lpKeyState"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetKeyboardState(byte[] lpKeyState);

    /// <summary>
    ///   SetWindowsHookEx
    /// </summary>
    /// <param name="idHook"></param>
    /// <param name="lpfn"></param>
    /// <param name="hMod"></param>
    /// <param name="dwThreadId"></param>
    /// <returns></returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern SafeWinHandle SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    /// <summary>
    ///   UnhookWindowsHookEx
    /// </summary>
    /// <param name="hhk"></param>
    /// <returns></returns>
    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

    /// <summary>
    ///   CallNextHookEx
    /// </summary>
    /// <param name="hhk"></param>
    /// <param name="nCode"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern IntPtr CallNextHookEx(SafeWinHandle hhk, int nCode, IntPtr wParam, ref NativeStructs.KBDLLHOOKSTRUCT lParam);

    /// <summary>
    ///   GetModuleHandle
    /// </summary>
    /// <param name="lpModuleName"></param>
    /// <returns></returns>
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern IntPtr GetModuleHandle(string lpModuleName);

    /// <summary>
    ///   GetAsyncKeyState
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    internal static extern short GetAsyncKeyState(Keys key);

    /// <summary>
    ///  GetKeyState
    /// </summary>
    /// <param name="vKey"></param>
    /// <returns></returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    internal static extern short GetKeyState(int vKey);

    /// <summary>
    ///  MapVirtualKey
    /// </summary>
    /// <param name="uCode"></param>
    /// <param name="uMapType"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern uint MapVirtualKey(uint uCode, uint uMapType);
  }
}
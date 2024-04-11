//  *****************************************************************************
//  File:      SafeWinHandle.cs
//  Solution:  Sentinel
//  Project:   Common
//  Date:      07/14/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System.Security;
using Microsoft.Win32.SafeHandles;

namespace TinTin.GUI.Common {
  public sealed class SafeWinHandle : SafeHandleZeroOrMinusOneIsInvalid {
    public SafeWinHandle() : base(true) {
    }

    [SecurityCritical]
    protected override bool ReleaseHandle() {
      return NativeStubs.UnhookWindowsHookEx(handle);
    }
  }
}
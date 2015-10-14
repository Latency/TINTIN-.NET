// *****************************************************************************
// File:      enm_VT100_Color.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

namespace TinTin.enums {
#if WINDOWS
  // ReSharper disable once InconsistentNaming
  public enum VT100_Color {
    Black,
    Blue,
    Green,
    Cyan,
    Red,
    Magenta,
    Yellow,
    Gray,
    BrightBlue,
    BrightGreen,
    BrightCyan,
    BrightRed,
    BrightMagenta,
    BrightYellow,
    White
  }

#else
  /// <summary>
  ///   30-37fg / 40-47bg
  /// </summary>
  // ReSharper disable once InconsistentNaming
  public enum VT100_Color {
    Black,
    Red,
    Green,
    Yellow,
    Blue,
    Magenta,
    Cyan,
    White
  }
#endif
}
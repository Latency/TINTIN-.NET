//  *****************************************************************************
//  File:       VT100_Color.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

namespace TinTin.Enums {
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

#else /// <summary>
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
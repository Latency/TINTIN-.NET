// *****************************************************************************
// File:      enm_VT100_Attributes.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************
// https://en.wikipedia.org/wiki/ANSI_escape_code#CSI_codes

using System.ComponentModel;

namespace TinTin.Enums {
// ReSharper disable once InconsistentNaming
  public enum VT00_Attributes {
    Reset,
    Bold,
    Faint,
    Italic,
    Underline,
    [Description("Blink Slow")]      BlinkS,
    [Description("Blink Rapid")]     BlinkR,
    [Description("Image: Negative")] Reverse,
    Conceal,
    [Description("Crossed-out")]     StrikeThrough,
    Reveal = 28
  }
}
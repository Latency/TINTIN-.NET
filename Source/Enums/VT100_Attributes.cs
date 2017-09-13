//  *****************************************************************************
//  File:       VT100_Attributes.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.ComponentModel;

namespace TinTin.Enums {
// ReSharper disable once InconsistentNaming
  public enum VT00_Attributes {
    Reset,
    Bold,
    Faint,
    Italic,
    Underline,

    [Description("Blink Slow")]
    BlinkS,

    [Description("Blink Rapid")]
    BlinkR,

    [Description("Image: Negative")]
    Reverse,
    Conceal,

    [Description("Crossed-out")]
    StrikeThrough,
    Reveal = 28
  }
}
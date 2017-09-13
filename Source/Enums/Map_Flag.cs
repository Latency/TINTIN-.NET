//  *****************************************************************************
//  File:       Map_Flag.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.ComponentModel;

namespace TinTin.Enums {
  // ReSharper disable InconsistentNaming
  // BitVector
  [Flags]
  public enum Map_Flag {
    [Description("Static")]
    Static,

    [Description("VT Map")]
    VTmap,

    [Description("VT Graphics")]
    VTgraphics,

    [Description("ASCII Graphics")]
    ASCIIGraphics,

    [Description("ASCII VNums")]
    ASCIIVNums,

    [Description("Mud Font")]
    MUDFont,

    [Description("No Follow")]
    NoFollow,

    [Description("Symbol Graphics")]
    SymbolGraphics
  }
  // ReSharper restore InconsistentNaming
}
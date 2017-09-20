//  *****************************************************************************
//  File:       Map_Dir.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

// ReSharper disable InconsistentNaming

using System;
using System.ComponentModel;

namespace TinTin.Enums {
  [Flags]
  public enum Map_Dir {
    [Description("North")]
    N = 1 << Map_Exit.N,

    [Description("East")]
    E = 1 << Map_Exit.E,

    [Description("South")]
    S = 1 << Map_Exit.S,

    [Description("West")]
    W = 1 << Map_Exit.W,

    [Description("Up")]
    U = 1 << Map_Exit.U,

    [Description("Down")]
    D = 1 << Map_Exit.D,

    [Description("North East")]
    NE = 1 << (Map_Exit.N | Map_Exit.E),

    [Description("North West")]
    NW = 1 << (Map_Exit.N | Map_Exit.W),

    [Description("South East")]
    SE = 1 << (Map_Exit.S | Map_Exit.E),

    [Description("South West")]
    SW = 1 << (Map_Exit.S | Map_Exit.W)
  }
}
//  *****************************************************************************
//  File:       Map_Exit.cs
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
  public enum Map_Exit {
    [Description("North")]
    N = 1,

    [Description("East")]
    E,

    [Description("South")]
    S,

    [Description("West")]
    W,

    [Description("Up")]
    U,

    [Description("Down")]
    D,

    [Description("North East")]
    NE,

    [Description("North West")]
    NW,

    [Description("South East")]
    SE,

    [Description("South West")]
    SW
  }
  // ReSharper restore InconsistentNaming
}
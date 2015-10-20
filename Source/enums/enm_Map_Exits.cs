// *****************************************************************************
// File:      enm_Map_Exits.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.ComponentModel;

namespace TinTin.Enums {
  // ReSharper disable InconsistentNaming
  // BitVector
  [Flags]
  public enum Map_Exits {
    [Description("North")] N,
    [Description("East")]  E,
    [Description("South")] S,
    [Description("West")]  W,
    [Description("Up")]    U,
    [Description("Down")]  D,
    [Description("North East")] NE,
    [Description("North West")] NW,
    [Description("South East")] SE,
    [Description("South West")] SW
  }
  // ReSharper restore InconsistentNaming
}
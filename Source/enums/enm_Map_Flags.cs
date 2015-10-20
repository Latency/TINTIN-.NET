// *****************************************************************************
// File:      enm_Map_Flags.cs
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
  public enum Map_Flags {
    [Description("Static")] Static,
    [Description("VT Map")] VTmap,
    [Description("VT Graphics")] VTgraphics,
    [Description("ASCII Graphics")] ASCIIGraphics,
    [Description("ASCII VNums")] ASCIIVNums,
    [Description("Mud Font")] MUDFont,
    [Description("No Follow")] NoFollow,
    [Description("Symbol Graphics")] SymbolGraphics
  }
  // ReSharper restore InconsistentNaming
}
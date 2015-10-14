// *****************************************************************************
// File:      enm_Map_Undo.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;

namespace TinTin.enums {
  // BitVector
  [Flags]
  // ReSharper disable once InconsistentNaming
  public enum Map_Undo {
    Move,
    Create,
    Link,
    Insert
  }
}
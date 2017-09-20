//  *****************************************************************************
//  File:       Map_Undo.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;

namespace TinTin.Enums {
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
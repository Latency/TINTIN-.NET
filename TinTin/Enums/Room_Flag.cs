//  *****************************************************************************
//  File:       Room_Flag.cs
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
  public enum Room_Flag {
    Avoid,
    Hide,
    Leave,
    Void,
    Static,
    River,
    Path
  }
}
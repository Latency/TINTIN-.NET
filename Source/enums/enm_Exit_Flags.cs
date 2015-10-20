// *****************************************************************************
// File:      enm_Exit_Flags.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;

namespace TinTin.Enums {
  // BitVector
  [Flags]
  // ReSharper disable once InconsistentNaming
  public enum Exit_Flags {
    Hide,
    Avoid
  }
}
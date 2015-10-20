// *****************************************************************************
// File:      enm_Telnet_Flags.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;

namespace TinTin.Enums {
  // ReSharper disable InconsistentNaming
  // Bitvector
  [Flags]
  public enum Telnet_Flags {
    SGA,
    ECHO,
    NAWS,
    PROMPT,
    DEBUG,
    TSPEED,
    TTYPE,
    MTTS
  }
  // ReSharper restore InconsistentNaming
}
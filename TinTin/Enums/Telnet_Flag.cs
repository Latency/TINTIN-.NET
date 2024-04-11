//  *****************************************************************************
//  File:       Telnet_Flag.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;

namespace TinTin.Enums {
  // ReSharper disable InconsistentNaming
  // Bitvector
  [Flags]
  public enum Telnet_Flag {
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
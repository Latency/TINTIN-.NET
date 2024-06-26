//  *****************************************************************************
//  File:       Tintin_Flag.cs
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
  public enum Tintin_Flag {
    ResetBuffer,
    ConvertMetaChar,
    HistoryBrowse,
    HistorySearch,
    ProcessInput,
    UserCommand, // Unused
    InsertInput,
    Verbatim, // Unused
    Terminate
  }
}
//  *****************************************************************************
//  File:       Command_Attributes.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

namespace TinTin.Enums {
  // ReSharper disable once InconsistentNaming
  public enum Command_Attributes {
    Ignore,
    Message,
    Debug,
    Log,
    Class,
    Read,
    Write,
    Show,
    Inherit,
    Nest,
    Default // = LIST_FLAG_MESSAGE
  }
}
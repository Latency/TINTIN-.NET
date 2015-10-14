// *****************************************************************************
// File:      enm_Command_Attributes.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

namespace TinTin.enums {
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
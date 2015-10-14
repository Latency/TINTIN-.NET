// *****************************************************************************
// File:      enm_Lexagraphical.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;

namespace TinTin.enums {
  // BitVector
  [Flags]
  public enum Lexagraphical {
    One, // stop at spaces
    All, // stop at semicolon
    NestSquareBrackets, // nest square brackets
    Verbatim // ignore semicolon for verbatim mode
  }
}
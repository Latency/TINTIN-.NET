//  *****************************************************************************
//  File:       Lexagraphical.cs
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
  public enum Lexagraphical {
    One, // stop at spaces
    All, // stop at semicolon
    NestSquareBrackets, // nest square brackets
    Verbatim // ignore semicolon for verbatim mode
  }
}
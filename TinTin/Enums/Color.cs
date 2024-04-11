//  *****************************************************************************
//  File:       Color.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;

// ReSharper disable InconsistentNaming

namespace TinTin.Enums {
  [Flags]
  public enum Color {
    BLD = 1,
    UND,
    BLK,
    REV,
    XTF,
    XTB,
    _256
  }
}
//  *****************************************************************************
//  File:       Get.cs
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
  public enum Get {
    ONE,    // Stop at spaces.
    ALL,    // Stop at semi-colon.
    NST,    // Nest square brackets.
    VBT     // Ignore semi-colon for verbatim mode.
  }
}
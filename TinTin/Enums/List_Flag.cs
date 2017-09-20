//  *****************************************************************************
//  File:       List_Flag.cs
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
  public enum List_Flag {
    Ignore,
    Message,
    Debug,
    Log,
    Class,
    Read,
    Write,
    Hide,
    Inherit,
    Nest,
    Default = Message
  }
}
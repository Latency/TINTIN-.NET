//  *****************************************************************************
//  File:       timer_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class timer_t : typedef<string> {
    // Default Constructor
    public timer_t() {
    }

    // Copy Constructor
    public timer_t(string name) : base(name) {
      Name = name;
    }

    // Properties
    public string Name { get; set; }
  }
}
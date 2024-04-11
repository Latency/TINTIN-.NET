//  *****************************************************************************
//  File:       line_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class line_t : typedef<KeyValuePair<string, Delegates.LINE>> {
    // Default Constructor
    public line_t() {
    }

    // Copy Constructor
    public line_t(KeyValuePair<string, Delegates.LINE> kvp) : base(kvp) {
      Name = kvp.Key;
      Func = kvp.Value;
    }

    // Properties
    public string Name { get; set; }

    public Delegates.LINE Func { get; set; }
  }
}
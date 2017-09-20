//  *****************************************************************************
//  File:       cursor_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class cursor_t : typedef<KeyValuePair<string, Delegates.CURSOR>> {
    // Default Constructor
    public cursor_t() {
    }

    // Copy Constructor
    public cursor_t(KeyValuePair<string, Delegates.CURSOR> kvp) : base(kvp) {
      Name = kvp.Key;
      Func = kvp.Value;
    }

    // Properties
    public string Name { get; set; }

    public string Desc { get; set; }

    public string Code { get; set; }

    public Delegates.CURSOR Func { get; set; }
  }
}
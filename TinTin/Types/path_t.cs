//  *****************************************************************************
//  File:       path_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class path_t : typedef<KeyValuePair<string, Delegates.PATH>> {
    // Default Constructor
    public path_t() {
    }

    // Copy Constructor
    public path_t(KeyValuePair<string, Delegates.PATH> kvp) : base(kvp) {
      Name = kvp.Key;
      Func = kvp.Value;
    }

    // Properties
    public string Name { get; set; }

    public Delegates.PATH Func { get; set; }
  }
}
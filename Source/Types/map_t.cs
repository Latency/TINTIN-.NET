//  *****************************************************************************
//  File:       map_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class map_t : typedef<KeyValuePair<string, Delegates.MAP>> {
    // Default Constructor
    public map_t() {
    }

    // Copy Constructor
    public map_t(KeyValuePair<string, Delegates.MAP> kvp) : base(kvp) {
      Name = kvp.Key;
      Map = kvp.Value;
    }

    // Properties
    public string Name { get; }

    public Delegates.MAP Map { get; }

    public int Check { get; set; }
  }
}
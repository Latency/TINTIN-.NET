//  *****************************************************************************
//  File:       event_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class event_t : typedef<KeyValuePair<string, string>> {
    // Default Constructor
    public event_t() {
    }

    // Copy Constructor
    public event_t(KeyValuePair<string, string> value) : base(value) {
      Name = value.Key;
      Description = value.Value;
    }

    // Properties
    public string Name { get; }

    public string Description { get; }
  }
}
//  *****************************************************************************
//  File:       color_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class color_t : typedef<KeyValuePair<string, string>> {
    // Default Constructor
    public color_t() {
    }

    // Copy Constructor
    public color_t(KeyValuePair<string, string> kvp) : base(kvp) {
      Name = kvp.Key;
      Code = kvp.Value;
    }

    // Properties
    public string Name { get; set; }

    public string Code { get; set; }
  }
}
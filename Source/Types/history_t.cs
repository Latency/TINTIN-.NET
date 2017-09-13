//  *****************************************************************************
//  File:       history_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace TinTin.Types {
  public class history_t : typedef<KeyValuePair<string, Delegates.HISTORY>> {
    // Default Constructor
    public history_t() {
    }

    // Copy Constructor
    public history_t(KeyValuePair<string, Delegates.HISTORY> kvp) : base(kvp) {
      Name = kvp.Key;
      Func = kvp.Value;
    }

    // Properties
    public string Name { get; set; }

    public Delegates.HISTORY Func { get; set; }

    public string Desc { get; set; }
  }
}
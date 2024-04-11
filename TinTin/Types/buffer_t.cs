//  *****************************************************************************
//  File:       buffer_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace TinTin.Types {
  public class buffer_t : typedef<KeyValuePair<string, Delegates.BUFFER>> {
    // Default Constructor
    public buffer_t() {
    }

    // Copy Constructor
    public buffer_t(KeyValuePair<string, Delegates.BUFFER> kvp) : base(kvp) {
      Name = kvp.Key;
      Func = kvp.Value;
    }

    // Properties
    public string Name { get; set; }

    public Delegates.BUFFER Func { get; set; }

    public string Desc { get; set; }
  }
}
//  *****************************************************************************
//  File:       array_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace TinTin.Types {
  public class array_t : typedef<Dictionary<string, string>> {
    // Default Constructor
    public array_t() {
    }

    // Copy Constructor
    public array_t(Dictionary<string, string> value) : base(value) {
    }

    // Properties
    public string name { get; set; }

    public Delegates.ARRAY array { get; set; }

    public int lval { get; set; }

    public int rval { get; set; }
  }
}
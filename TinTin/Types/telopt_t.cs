//  *****************************************************************************
//  File:       telopt_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

// ReSharper disable InconsistentNaming

using System.Collections.Generic;
using BitFields;

namespace TinTin.Types {
  public class telopt_t : typedef<KeyValuePair<string, BitField>> {
    // Default Constructor
    public telopt_t() {
    }

    // Copy Constructor
    public telopt_t(KeyValuePair<string, BitField> kvp) : base(kvp) {
      Name = kvp.Key;
      Flags = kvp.Value;
    }

    // Properties
    public string Name { get; }

    public int Want { get; set; }

    public BitField Flags { get; set; }
  }
}
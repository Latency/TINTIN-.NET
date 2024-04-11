//  *****************************************************************************
//  File:       term_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;
using BitFields;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class term_t : typedef<KeyValuePair<string, BitField>> {
    // Default Constructor
    public term_t() {
    }

    // Copy Constructor
    public term_t(KeyValuePair<string, BitField> kvp) : base(kvp) {
      Name = kvp.Key;
      Flags = kvp.Value;
    }

    // Properties
    public string Name { get; set; }

    public BitField Flags { get; set; }
  }
}
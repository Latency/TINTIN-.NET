// *****************************************************************************
// File:      term_t.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Collections.Generic;

namespace TinTin.types {
  // ReSharper disable once InconsistentNaming
  public class term_t : typedef<Dictionary<string, ulong>> {
    // Default Constructor
    public term_t() {}
    // Copy Constructor
    public term_t(Dictionary<string, ulong> value) : base(value) {}
    // Properties
    public string Name { get; set; }
    public ulong Flag { get; set; }
  }
}
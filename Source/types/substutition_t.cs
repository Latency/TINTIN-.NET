// *****************************************************************************
// File:      substutition_t.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Collections.Generic;
using BitFields;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class substitution_t : typedef<Dictionary<string, BitField>> {
    // Default Constructor
    public substitution_t() {}
    // Copy Constructor
    public substitution_t(Dictionary<string, BitField> value) : base(value) {}
    // Properties
    public string Name { get; set; }
    public BitField BitField { get; set; }
  }
}
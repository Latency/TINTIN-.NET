// *****************************************************************************
// File:      color_t.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class color_t : typedef<Dictionary<string, string>> {
    // Default Constructor
    public color_t() {}
    // Copy Constructor
    public color_t(Dictionary<string, string> value) : base(value) {}
    // Properties
    public string Name { get; set; }
    public string Code { get; set; }
  }
}
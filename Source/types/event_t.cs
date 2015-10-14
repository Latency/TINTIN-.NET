// *****************************************************************************
// File:      event_t.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Collections.Generic;

namespace TinTin.types {
  // ReSharper disable once InconsistentNaming
  public class event_t : typedef<Dictionary<string, string>> {
    // Default Constructor
    public event_t() {}
    // Copy Constructor
    public event_t(Dictionary<string, string> value) : base(value) {}
    // Properties
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
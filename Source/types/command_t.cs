// *****************************************************************************
// File:      command_t.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.Collections.Generic;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class command_t : typedef<Session> {
    // Default Constructor
    public command_t() {}
    // Copy Constructor
    public command_t(Session session, KeyValuePair<string, Action<string>> kvp) : base(session) {
      Name = kvp.Key;
      Command = kvp.Value;
    }
    // Properties
    public string Name { get; private set; }
    public Action<string> Command { get; private set; }
  }
}
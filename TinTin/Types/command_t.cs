//  *****************************************************************************
//  File:       command_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class command_t : typedef<Session> {
    // Default Constructor
    public command_t() {
    }

    // Copy Constructor
    public command_t(Session session, KeyValuePair<string, Delegates.COMMAND> kvp) : base(session) {
      Name = kvp.Key;
      Command = kvp.Value;
    }

    // Properties
    public string Name { get; }

    public Delegates.COMMAND Command { get; }

    public int type { get; set; }
  }
}
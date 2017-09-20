//  *****************************************************************************
//  File:       config_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class config_t : typedef<Session> {
    // Default Constructor
    public config_t() {
    }

    // Copy Constructor
    public config_t(Session session, KeyValuePair<string, Delegates.CONFIG> kvp) : base(session) {
      Name = kvp.Key;
      Config = kvp.Value;
    }

    // Properties
    public string Name { get; }

    public string msg_on { get; set; }

    public string msg_off { get; set; }

    public Delegates.CONFIG Config { get; }
  }
}
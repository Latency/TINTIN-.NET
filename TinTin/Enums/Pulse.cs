//  *****************************************************************************
//  File:       Pulse.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

namespace TinTin.Enums {
  public enum Pulse {
    PollInput = 1,
    PollSessions = 1,
    PollChat = 1,
    PollPort = 2,
    UpdateTicks = 1,
    UpdateDelays = 1,
    UpdatePackets = 2,
    UpdateChat = 2,
    UpdateTerminal = 1,
    UpdateMemory = 2,
    UpdateTime = 20
  }
}
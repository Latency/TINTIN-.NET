//  *****************************************************************************
//  File:       Timer.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

namespace TinTin.Enums {
  // ReSharper disable InconsistentNaming
  public enum Timer {
    PollInput,
    PollSessions,
    PollChat,
    UpdateTicks,
    UpdateDelays,
    UpdatePackets,
    UpdateChat,
    UpdateTerminal,
    UpdateTime,
    UpdateMemory,
    StallProgram,
    CPU
  }
  // ReSharper restore InconsistentNaming
}
// *****************************************************************************
// File:      enm_Timer.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

namespace TinTin.enums {
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
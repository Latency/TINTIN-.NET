// *****************************************************************************
// File:      ExitData.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

namespace TinTin.Structs {
  public struct ExitData {
    // ReSharper disable InconsistentNaming
    public string cmd,
                  data,
                  name;

    public int dir,
               flags,
               vnum;
    // ReSharper restore InconsistentNaming
  }
}
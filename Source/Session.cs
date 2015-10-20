// *****************************************************************************
// File:      Session.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using TinTin.Enums;
using TinTin.Structs;

namespace TinTin {
  public class Session {
    private SessionData _session;
    public Session() {}

    public Session(SessionData session) {
      _session = session;
    }

    public bool IsSplit => (_session.termInfo.rows != _session.termInfo.bot_row || _session.termInfo.top_row != -1);
    public bool Scroll => (_session.termInfo.cur_row == 0 || (_session.termInfo.cur_row >= _session.termInfo.top_row && _session.termInfo.cur_row <= _session.termInfo.bot_row) || _session.termInfo.cur_row == _session.termInfo.rows);
    public bool Verbatim => (_session.input_level == 0 && _session.flags.IsSet((ulong) Session_Flags.Verbatim));

    // ReSharper disable InconsistentNaming
    public delegate Session ARRAY(ListNode list, string arg);

    public delegate Session CLASS(string left, string right);

    public delegate Session CONFIG(string arg, int index);

    public delegate Session COMMAND(string arg);

    public delegate Session LINE(string arg);

    public delegate void CHAT(string left, string right);

    public delegate void MAP(string arg, string arg1, string arg2);

    public delegate void PATH(string arg);

    public delegate void HISTORY(string arg);

    public delegate void BUFFER(string arg);

    // ReSharper restore InconsistentNaming
  }
}
//  *****************************************************************************
//  File:       Session.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using TinTin.Enums;
using TinTin.Structs;

namespace TinTin {
  public class Session {
    private SessionData _session;

    public Session() {
    }

    public Session(SessionData session) {
      _session = session;
    }

    public bool IsSplit => _session.termInfo.rows != _session.termInfo.bot_row || _session.termInfo.top_row != -1;

    public bool Scroll => _session.termInfo.cur_row == 0 || _session.termInfo.cur_row >= _session.termInfo.top_row && _session.termInfo.cur_row <= _session.termInfo.bot_row ||
                          _session.termInfo.cur_row == _session.termInfo.rows;

    public bool Verbatim => _session.input_level == 0 && _session.flags.IsSet((ulong) Session_Flag.Verbatim);
  }
}
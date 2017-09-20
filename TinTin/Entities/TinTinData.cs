//  *****************************************************************************
//  File:       TinTinData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using BitFields;
using TinTin.Enums;

// ReSharper disable InconsistentNaming

namespace TinTin.Entities {
  public class TinTinData {
    public Session      session,
                        update,
                        dispsoe_next,
                        dispose_prev;
    public ChatData     chat;
   // public Termios     old_terminal,
   //                    new_terminal;
    public string       mud_output_buf,
                        mccp_buf,
                        home,
                        term;
    public int          mud_output_max,
                        mud_output_len,
                        mccp_len,
                        input_off,
                        input_len,
                        input_cur,
                        input_pos,
                        input_hid,
                        input_tab,
                        str_size,
                        str_hash_size,
                        history_size,
                        quiet,
                        noise_level,
                        debug_level,
                        input_level;
    public int[]        command_ref;
    public char         tintin_char,
                        verbatim_char,
                        repeat_char;
    public StringBuilder  input_buf,
                          input_tmp,
                          macro_buf,
                          paste_buf;
    public TimeSpan       time;
    public long         total_io_ticks,
                        total_io_exec,
                        total_io_delay;
    public BitField     flags;
    public List<TimeSpan>[] timer;
    public List<string> vars,
                        cmds;
    public List<int>    args;

    public TinTinData() {
      for (var x = 0; x < 5; x++) {
        timer[x] = new List<TimeSpan>(Enum.GetNames(typeof(Timer)).Length);
      }
    }
  }
}
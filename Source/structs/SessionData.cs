// *****************************************************************************
// File:      SessionData.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Collections.Generic;
using System.IO;
using BitFields;

namespace TinTin.structs {
  public struct SessionData {
    // ReSharper disable InconsistentNaming
    public int auto_tab;
    public int bgc;
    public Queue<string> buffer;
    public long check_output;
    public string cmd_color;
    public string color;
    public int connect_error;
    public long connect_retry;
    public int debug_level;
    public int fgc;
    public BitField flags;

    public string group,
                  host;

    public int input_level;
    public string ip;
    public FileStream logfile;
    public string more_output;
    public string name;
    public string port;
    public string read_buf;

    public int read_len,
               read_max;

    public int socket;

    //public FileStream logline;

    //public ListRoot[] list;
    //public ListRoot   history;

    public int[] telopt_flag;
    public int telopts;
    public TerminalData termInfo;
    public int vtc;
    // ReSharper restore InconsistentNaming
  }
}
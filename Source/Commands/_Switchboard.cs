//  *****************************************************************************
//  File:       _Switchboard.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using CSTypes;
using TinTin.Interfaces;
using TinTin.Properties;

namespace TinTin.Commands {
  internal sealed partial class Switchboard : ICommands {
    // Constructor
    public Switchboard() {
      CMD = new Dictionary<string, Delegate>();
      foreach (var m in typeof(ICommands).GetMethods().Where(x => !x.IsSpecialName))
        CMD.Add(m.Name.ToLower(), Delegate.CreateDelegate(typeof(Action<string>), this, m));
    }

    // ReSharper disable once InconsistentNaming
    public Dictionary<string, Delegate> CMD { get; }

    /// <summary>
    ///   ProcessCommand
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public KeyValuePair<string, Delegate> ProcessCommand(string line) {
      if (string.IsNullOrEmpty(line) || line[0] != Settings.Default.TINTIN_CHAR)
        return default(KeyValuePair<string, Delegate>);
      // Strip the TINTIN_CHAR from the line,.
      // Cut the command out of the parameter list.
      // Re-assign the <i>kvp.Key</i> to the parameter list.
      // Assign the delegate mapping to the <i>kvp.Key</i> to the <i>kvp.Value</i>.
      var ai = new ArgInterpreter(line.TrimStart(' ', Settings.Default.TINTIN_CHAR), ArgTypes.Cut);
      return new KeyValuePair<string, Delegate>(ai.Tokens[1].Trim(), CMD.Where(x => x.Key == ai.Tokens[0].ToLower()).Select(x => x.Value).FirstOrDefault());
    }
  }
}
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
using System.Xml;
using CSTypes;
using TinTin.Interfaces;
using TinTin.Properties;

namespace TinTin.Commands {
  internal sealed partial class Switchboard : ICommands {
    private static Switchboard _instance;

    public static Switchboard Instance => _instance ?? (_instance = new Switchboard());

    // Constructor
    private Switchboard() {
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
      if (string.IsNullOrEmpty(line) || line[0] != Resources.TINTIN_CHAR[0])
        return default(KeyValuePair<string, Delegate>);
      // Strip the TINTIN_CHAR from the line,.
      // Cut the command out of the parameter list.
      // Re-assign the <i>kvp.Key</i> to the parameter list.
      // Assign the delegate mapping to the <i>kvp.Key</i> to the <i>kvp.Value</i>.
      var ai = new ArgInterpreter(line.TrimStart(' ', Resources.TINTIN_CHAR[0]), ArgTypes.Cut);
      var buf = ai.Tokens.Count > 1 ? ai.Tokens[1] : string.Empty;
      return new KeyValuePair<string, Delegate>(buf.Trim(), CMD.Where(x => x.Key == ai.Tokens[0].ToLower()).Select(x => x.Value).FirstOrDefault());
    }


    /// <summary>
    ///  Usage
    /// </summary>
    /// <param name="method"></param>
    private void Usage(string method) {
      var item = Program.TinTin.help[method];
      var b = item.GetElementsByTagName("Command")[0];
      if (b.Attributes == null)
        return;
      foreach (XmlAttribute a in b.Attributes) {
        if (a.Name != "Name" || a.Value != method)
          continue;
        const string syntax = "Syntax";
        foreach (XmlNode usage in item.GetElementsByTagName(syntax))
          Program.Print($"{syntax}:  {a.Value} {usage.InnerText}");
        return;
      }
    }
  }
}
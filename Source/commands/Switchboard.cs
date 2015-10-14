// *****************************************************************************
// File:      Switchboard.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using TinTin.Interfaces;
using TinTin.types;

namespace TinTin.commands {
  public partial class Switchboard {
    private readonly command_t _session;

    private static TDelegate GetParameterlessInstanceMethod<TDelegate>(MethodInfo method) {
      if (method.ReflectedType != null) {
        var x = Expression.Parameter(method.GetParameters()[0].ParameterType, "str");
        return Expression.Lambda<TDelegate>(Expression.Call(x, method), x).Compile();
      }
      throw new TypeAccessException();
    }

    // Constructor
    public Switchboard() {
      CMD = new Dictionary<string, Action<string>>();
      foreach (var m in typeof(ICommands).GetMethods().Where(x => !x.IsSpecialName)) {
        CMD.Add(m.Name.ToLower(), GetParameterlessInstanceMethod<Action<string>>(m));
      }
    }

    // Copy Constructor
    public Switchboard(command_t session) {
      _session = session;
    }

    // ReSharper disable once InconsistentNaming
    public Dictionary<string, Action<string>> CMD { get; }
  }
}
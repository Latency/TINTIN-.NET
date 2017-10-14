//  *****************************************************************************
//  File:       TypeMap.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       10/08/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;

namespace TinTin {
  internal static class TypeMap {
    private static readonly Dictionary<string, string> List;
    
    static TypeMap() {
      List = new Dictionary<string, string> {
        {"bool",    "System.Boolean"},
        {"byte",    "System.Byte"},
        {"sbyte",   "System.SByte"},
        {"char",    "System.Char"},
        {"decimal", "System.Decimal"},
        {"double",  "System.Double"},
        {"float",   "System.Single"},
        {"int",     "System.Int32"},
        {"uint",    "System.UInt32"},
        {"long",    "System.Int64"},
        {"ulong",   "System.UInt64"},
        {"object",  "System.Object"},
        {"short",   "System.Int16"},
        {"ushort",  "System.UInt16"},
        {"string",  "System.String"}
      };
    }
    
    
    public static Type Convert(string name) {    
      //
      // Map the C# built-in types to the .NET Framework Types
      // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/built-in-types-table
      //
      foreach (var type in List) {
        if (name == type.Key) {
          name = type.Value;
          break;
        }
      }

      try {
        return Type.GetType(name);
      } catch (TypeLoadException e) {
        Program.Print($"Unable to load type `{e.GetType().Name}'");
        return null;
      }
    }
  }
}
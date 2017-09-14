//  *****************************************************************************
//  File:       Print.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Linq;
using TinTin.Properties;

namespace TinTin {
  internal static partial class Program {
    internal static void Print(string s) {
      // Terminal.Allocate();

      s.Split(new[] {
        "\r\n",
        "\n\r",
        "\n"
      }, StringSplitOptions.RemoveEmptyEntries).Aggregate(string.Empty, (x, line) => {
        Console.WriteLine($"{Settings.Default.PromptChar}{line}");
        return null;
      });

      // Terminal.Free();
    }
  }
}
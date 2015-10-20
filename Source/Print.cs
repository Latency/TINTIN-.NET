﻿// *****************************************************************************
// File:      Print.cs
// Solution:  TinTin.NET
// Date:      10/19/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.Windows.Forms;
using TinTin.Properties;

namespace TinTin {
  internal static partial class Program {
    internal static void Print(string s) {
      if (_sdData.GUI) {
        MessageBox.Show(s, "Print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      foreach (var line in s.Split(new[] { "\r\n", "\n\r", "\n" }, StringSplitOptions.None))
        Console.WriteLine($"{Settings.Default.PromptChar}{line}");
    }
  }
}
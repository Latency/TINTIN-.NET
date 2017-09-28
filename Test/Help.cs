//  *****************************************************************************
//  File:       TestClass.cs
//  Solution:   TinTin.NET
//  Project:    Tests
//  Date:       09/12/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using NUnit.Framework;
using TinTin;


namespace Test {
  [TestFixture]
  public class Tests {
    [Test]
    public void HelpTest() {
      var help = Help.Instance;
      Console.WriteLine($"Help entries loaded = {Program.TinTin.help.Count}");
    }
  }
}
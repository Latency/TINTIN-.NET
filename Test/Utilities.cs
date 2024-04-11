//  *****************************************************************************
//  File:       Class1.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/16/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CSTypes;

namespace Test {
  internal static class Utilities {
    /// <summary>
    ///  Used for converting Help\*.txt files into *.xml files.
    /// </summary>
    public static void HelpConverter() {
      var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Help";
      var files = Directory.GetFiles(path, "*.txt");
      foreach (var file in files) {
        var data = File.ReadAllLines(file).Skip(2);
        var textInfo = new CultureInfo("en-US", false).TextInfo;
        var command = textInfo.ToTitleCase(Path.GetFileNameWithoutExtension(file));
        var arg = new ArgInterpreter(data.First().Substring(9), ArgTypes.Cut);
        var str = data.Skip(1);
        var strm = new StringBuilder();
        foreach (var line in str) {
          strm.AppendLine(line);
        }
        var str1 = strm.ToString();

        var doc = new XDocument(
          new XElement("Help",
            new XElement("Command",
              new XAttribute("Name", command),
              new XAttribute("Modified", DateTime.Now.ToShortDateString())
            ),
            new XElement("Syntax", arg.Tokens[1]),
            new XElement("Description", str1)
          )
        );
        doc.Save(path + @"\" + command + ".xml");
      }
    }
  }
}
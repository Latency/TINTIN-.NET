//  *****************************************************************************
//  File:       Help.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using static System.Math;

namespace TinTin.Commands {
  internal sealed partial class Switchboard {  
    public void Help(string s) {
      var arg = new CSTypes.ArgInterpreter(s, CSTypes.ArgTypes.Cut);
      switch (arg.Tokens.Count) {
        case 0: {
          // Display all help entries.
          var sb = new StringBuilder();
          Usage(MethodBase.GetCurrentMethod().Name);
          sb.AppendLine(new string('=', Max(2, Program.Terminal.cols - 2)));
          foreach (var kvp in Program.TinTin.help) {
            var b = kvp.Value.GetElementsByTagName("Command")[0];
            if (b.Attributes == null)
              continue;
            foreach (XmlAttribute a in b.Attributes) {
              if (a.Name == "Name")
                sb.AppendLine(a.Value);
            }
          }
          Program.Print(sb.ToString());
          break;
        }
        case 1: {
          // Display specific help file.
          var helpFile = char.ToUpperInvariant(arg.Tokens[0][0]) + arg.Tokens[0].Substring(1);
          var xml = Program.TinTin.help[helpFile];
          if (xml == null)
            break;
          var sb = new StringBuilder();
          var xEle = XElement.Load(new XmlNodeReader(xml));

          foreach (var emp in xEle.Descendants()) {
            sb.AppendLine($"{emp.Name.LocalName}:  ");
            switch (emp.Name.LocalName) {
              case "Command":
                if (!string.IsNullOrEmpty(emp.Value))
                  throw new InvalidDataContractException();
                sb.AppendLine($"    `help {emp.Attribute("Name").Value}'");
                break;
              case "Syntax":
                sb.AppendLine($"    {emp.Value}");
                break;
              case "Description":
                sb.AppendLine($"{emp.Value}");
                break;
              case "Example":
                var buf = string.Empty;
                var deflt = emp.Attribute("Default");
                if (!string.IsNullOrEmpty(deflt?.Value))
                  buf = $"{' ',10}Default:  {deflt.Value}";
                sb.AppendLine($"    Usage:  {emp.Attribute("Usage").Value}{buf}");
                sb.AppendLine($"{emp.Value}");
                break;
              case "Notes":
                sb.AppendLine($"{emp.Value}");
                break;
            }
          }
          Program.Print(sb.ToString());
          break;
        }
        default:
          // Display usage.
          Usage(MethodBase.GetCurrentMethod().Name);
          break;
      }
    }
  }
}
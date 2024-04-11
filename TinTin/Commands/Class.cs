//  *****************************************************************************
//  File:       Class.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using TinTin.Properties;
using System.Linq;
using TinTin.Interfaces;
using Env = System.Environment;
using static System.Math;

namespace TinTin.Commands {
  internal sealed partial class Switchboard {
    public void Class(string s) {      
      var arg = new CSTypes.ArgInterpreter(s, CSTypes.ArgTypes.Cut);
      switch (arg.Tokens.Count) {
        case 0: {
          if (Program.TinTin.classes.Count == 0)
            Program.Print("There are no classes registered.");
          else {
            var sb = new StringBuilder();
            foreach (var c in Program.TinTin.classes)
              sb.AppendLine(c.Key);
            if (sb.Length > 0)
              Program.Print($"Class Objects Registered{Env.NewLine}{new string('=', Max(2, Program.Terminal.cols - 2))}{Env.NewLine}{sb}");
          }
          break;
        }
          
        case 1: {
          foreach (var obj in Program.TinTin.classes) {
            if (obj.Key == arg.Tokens[0]) {
              var sb = new StringBuilder();
              sb.AppendLine($"class {obj.Key} " + '{');
              PropertyInfo[] pi = obj.Value.GetType().GetProperties();
              string Func(MethodBase d) => d.IsPublic ? string.Empty : (d.IsPrivate ? "private " : "protected");
              foreach (var prop in pi)
                sb.AppendLine($"  {prop.PropertyType,-15} {prop.Name,-20} {{ {Func(prop.GetMethod)}get; {Func(prop.SetMethod)}set; }}");
              sb.AppendLine("}");
              Program.Print(sb.ToString());
              return;
            }
          }
          Program.Print($"No class found with the name `{arg.Tokens[0]}'.");
          break;
        }

        case 2: {
          var json = arg.Tokens[1];
          if (string.IsNullOrEmpty(json) || (!json.StartsWith("{") || !json.EndsWith("}")) && (!json.StartsWith("[") || !json.EndsWith("]"))) {
            Usage(MethodBase.GetCurrentMethod().Name);
            return;
          }

          try {
            JSchema schema;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(Resources.CLASS_SCHEMA)) {
              using (var reader = new StreamReader(stream ?? throw new NullReferenceException($"Unable to fetch embedded resource for `{Resources.CLASS_SCHEMA}'.")))
                schema = JSchema.Parse(reader.ReadToEnd());
            }

            if (schema == null) {
              Program.Print("Unable to load embedded resource schema for class definitions.");
              return;
            }

            if (!JObject.Parse(json).IsValid(schema)) {
              Program.Print($"Invalid schema for class definition `{arg.Tokens[0]}'.");
              return;
            }

          } catch (JsonReaderException ex) {
            //Exception in parsing json
            Program.Print(ex.Message);
            return;
          }

          Dictionary<string, string> list = JsonConvert.DeserializeObject<dynamic>(json).ToObject<Dictionary<string, string>>();
          var fields = list.Select(property => new DynamicClass.MyPropertyInfo(property.Key, TypeMap.Convert(property.Value.ToString())));
          var myPropertyInfos = fields as IList<DynamicClass.MyPropertyInfo> ?? fields.ToList();
          dynamic tx = DynamicClass.New<IComplexType>(new KeyValuePair<string, string>(arg.Tokens[0], arg.Tokens[1]),  myPropertyInfos);

          Program.TinTin.classes.Add(arg.Tokens[0], tx);
          Program.Print($"Class `{arg.Tokens[0]}' was successfully registered.");
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
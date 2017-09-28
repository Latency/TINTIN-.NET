//  *****************************************************************************
//  File:       Help.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/20/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using Microsoft.Extensions.Logging;
using TinTin.Properties;

namespace TinTin {
  public sealed class Help {
    private static Help _instance;

    public static Help Instance => _instance ?? (_instance = new Help());


    /// <summary>
    ///  Constructor
    /// </summary>
    private Help() {
      var assembly = Assembly.GetAssembly(typeof(Help));

      // Load schema definition file.
      var strm = assembly.GetManifestResourceStream(Resources.HELP_SCHEMA);
      var xsd = XmlSchema.Read(strm ?? throw new NullReferenceException($"Unable to fetch embedded resource for `{Resources.HELP_SCHEMA}'."), null);

      // Cache help files.
      foreach (var resourceName in assembly.GetManifestResourceNames().Where(name => name.EndsWith(".xml"))) {
        var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
          throw new NullReferenceException($"Unable to fetch embedded resource for `{resourceName}'.");

        var document = new XmlDocument();
        using (stream) {
          try {
            document.Schemas.Add(xsd);
            document.Load(stream);
            document.Validate(null);
          } catch (XmlSchemaValidationException) {
            Program.Log.LogInformation($"{GetType().Namespace}.{GetType().Name}.{MethodBase.GetCurrentMethod().Name}{Environment.NewLine}\tSchema validation failed for `{resourceName}'.");
            throw;
          } catch (XmlException) {
            Program.Log.LogError($"{GetType().Namespace}.{GetType().Name}.{MethodBase.GetCurrentMethod().Name}{Environment.NewLine}\tDocument loading failed for `{resourceName}'.");
            throw;
          }
          // Cache stream into memory.
          Program.TinTin.help.Add(document);
        }
      }
    }
  }
}
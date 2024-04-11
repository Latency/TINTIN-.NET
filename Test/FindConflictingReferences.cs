//  *****************************************************************************
//  File:       FindConflictingReferences.cs
//  Solution:   TinTin.NET
//  Project:    Test
//  Date:       10/21/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Test {
  [TestFixture]
  public class UtilityTest {
    private static IEnumerable<IGrouping<string, Reference>> FindReferencesWithTheSameShortNameButDiffererntFullNames(
      IEnumerable<Reference> references) {
      return from reference in references
        group reference by reference.ReferencedAssembly.Name
        into referenceGroup
        where referenceGroup.ToList().Select(reference => reference.ReferencedAssembly.FullName).Distinct().Count() > 1
        select referenceGroup;
    }

    private static IEnumerable<Reference> GetReferencesFromAllAssemblies(IEnumerable<Assembly> assemblies) {
      return (from assembly in assemblies
        from referencedAssembly in assembly.GetReferencedAssemblies()
        select new Reference {
          Assembly = assembly.GetName(),
          ReferencedAssembly = referencedAssembly
        }).ToList();
    }

    private static IEnumerable<Assembly> GetAllAssemblies(string path) {
      var files = new List<FileInfo>();
      var directoryToSearch = new DirectoryInfo(path);
      files.AddRange(directoryToSearch.GetFiles("*.dll", SearchOption.AllDirectories));
      files.AddRange(directoryToSearch.GetFiles("*.exe", SearchOption.AllDirectories));
      return files.ConvertAll(file => Assembly.LoadFile(file.FullName));
    }

    private class Reference {
      public AssemblyName Assembly { get; set; }
      public AssemblyName ReferencedAssembly { get; set; }
    }

    [Test]
    public void FindConflictingReferences() {
     var assemblies = GetAllAssemblies(@"D:\Documents\Visual Studio 2017\Projects\TinTin#\TinTin\bin\Debug\net471");

      var references = GetReferencesFromAllAssemblies(assemblies);

      var groupsOfConflicts = FindReferencesWithTheSameShortNameButDiffererntFullNames(references);

      foreach (var group in groupsOfConflicts) {
        Console.Out.WriteLine("Possible conflicts for {0}:", group.Key);
        foreach (var reference in group)
          Console.Out.WriteLine("{0} references {1}",
            reference.Assembly.Name.PadRight(25),
            reference.ReferencedAssembly.FullName);
      }
    }
  }
}
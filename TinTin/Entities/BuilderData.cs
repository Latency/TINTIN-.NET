//  *****************************************************************************
//  File:       BuilderData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       10/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Reflection;
using System.Reflection.Emit;
// ReSharper disable InconsistentNaming

namespace TinTin.Entities {
  internal class BuilderData {
    public BuilderData() {
      _methodAttributes = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual;
    }

    public FieldBuilder _fieldBuilder { get; set; }
    public MethodAttributes _methodAttributes { get; set; }
    public PropertyBuilder _propertyBuilder { get; set; }
    public TypeBuilder _typeBuilder { get; set; }
  }
}
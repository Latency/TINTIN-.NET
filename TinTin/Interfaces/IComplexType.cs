//  *****************************************************************************
//  File:       IComplexType.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       10/10/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.ComponentModel;

namespace TinTin.Interfaces {
  /// <summary>
  /// </summary>
  public interface IComplexType {
    /// <summary>
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once InconsistentNaming
    string JSON { get; set; }

    /// <summary>
    /// </summary>
    [Bindable(true)]
    [TypeConverter(typeof(StringConverter))]
    object PropertyInfo { get; set; }
  }
}
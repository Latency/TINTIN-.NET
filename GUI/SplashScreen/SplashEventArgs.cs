//  *****************************************************************************
//  File:       SplashEventArgs.cs
//  Solution:   Sentinel
//  Project:    Sentinel
//  Date:       09/05/2016
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2016
//  *****************************************************************************

using System;
using System.Windows.Threading;


namespace TinTin.GUI.SplashScreen {
  public class SplashEventArgs : EventArgs {
    /// <inheritdoc />
    /// <summary>
    ///  SplashEventArgs
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="value"></param>
    /// <param name="collection"></param>
    public SplashEventArgs(string methodName, string value, DispatcherTimer collection) {
      Name = methodName;
      Value = value;
      Timer = collection;
    }


    /// <summary>
    ///  Name
    /// </summary>
    public string Name { get; }


    /// <summary>
    ///  Value
    /// </summary>
    public string Value { get; }


    /// <summary>
    ///  Items
    /// </summary>
    public DispatcherTimer Timer { get; }
  }
}
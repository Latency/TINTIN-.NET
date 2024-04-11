//  *****************************************************************************
//  File:      Extensions.cs
//  Solution:  Sentinel
//  Project:   Sentinel
//  Date:      08/29/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Threading;

namespace TinTin.GUI.Common {
  public static class Extensions {
    // ReSharper disable once InconsistentNaming
    /// <summary>
    ///   Used to compare OS version ranges.
    /// </summary>
    /// <param name="os"></param>
    /// <param name="startVersion"></param>
    /// <param name="endVersion"></param>
    /// <returns></returns>
    public static bool IsMinOSVersion(this OperatingSystem os, OSVersion startVersion, OSVersion endVersion = OSVersion.All) {
      var vs = OSVersionInfo.Version;
      var enm = OSVersion.Other;

      switch (vs.Major) {
        case 3:
          // "NT 3.51";
          enm = OSVersion.WinNT;
          break;
        case 4:
          // "NT 4.0";
          enm = OSVersion.WinNT;
          break;
        case 5:
          switch (vs.Minor) {
            case 0:
              // "2000";
              enm = OSVersion.Win2000;
              break;
            case 1:
              // "XP";
              enm = OSVersion.XP;
              break;
            default:
              enm = OSVersion.XP;
              break;
          }
          break;
        case 6:
          switch (vs.Minor) {
            case 0:
              // "Vista";
              enm = OSVersion.Vista;
              break;
            case 1:
              // "7";
              enm = OSVersion.Win7;
              break;
            case 2:
              // "8.0";
              enm = OSVersion.Win8;
              break;
            default:
              enm = OSVersion.Win8;
              break;
          }
          break;
        case 10:
          // "10";
          enm = OSVersion.Win10;
          break;
      }

      return (int) startVersion >= (int) enm && (int) enm <= (int) endVersion;
    }


    /// <summary>
    ///  FindAssemblyForGuid
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    public static Assembly FindAssemblyForGuid(Guid match) {
      //foreach (var a in AppDomain.CurrentDomain.GetAssemblies()) {
      //  var attributes = a.GetCustomAttributes(typeof(GuidAttribute));
      //  if (attributes.Any()) {
      //    foreach (var g in attributes) {
      //      var b = g as GuidAttribute;
      //      if (b != null)
      //        if (b.Value == match.ToString())
      //          return a;
      //    }
      //  }
      //}
      //return null; // failed to find it

      return (from a in AppDomain.CurrentDomain.GetAssemblies() let attributes = a.GetCustomAttributes(typeof (GuidAttribute)) where attributes.Any() && attributes.OfType<GuidAttribute>().Any(b => b.Value == match.ToString()) select a).FirstOrDefault();
    }


    /// <summary>
    ///   Obtains ownership of a directory.
    /// </summary>
    /// <param name="pathToDirctory"></param>
    public static bool TakeOwnership(string pathToDirctory) {
      var directoryInfo = new DirectoryInfo(pathToDirctory);
      var path = directoryInfo.FullName;
      if (!directoryInfo.Exists)
        return false;

        var directorySecurity = directoryInfo.GetAccessControl();
        var windowsIdentity = WindowsIdentity.GetCurrent();
        if (windowsIdentity.User != null)
          directorySecurity.SetOwner(windowsIdentity.User);
        Directory.SetAccessControl(path, directorySecurity);

      return true;
    }


    /// <summary>
    ///   Extension method for Process type.
    /// </summary>
    /// <param name="process"></param>
    /// <returns></returns>
    public static bool IsRunning(this Process process) {
      if (process == null)
        throw new ArgumentNullException(nameof(process));
      try {
        Process.GetProcessById(process.Id);
      } catch (ArgumentException) {
        return false;
      }
      return true;
    }


    /// <summary>
    ///  Simple helper extension method to marshall to correct thread if its required
    /// </summary>
    /// <param name="control"></param>
    /// <param name="methodcall"></param>
    /// <param name="priorityForCall"></param>
    /// <param name="parameters"></param>
    public static T InvokeIfRequired<T>(this DispatcherObject control, Func<object[], T> methodcall, DispatcherPriority priorityForCall, params object[] parameters) {
      // CheckAccess returns true if you're on the dispatcher thread.
      return !control.Dispatcher.CheckAccess() ? (T) control.Dispatcher.Invoke(priorityForCall, methodcall, parameters) : methodcall(parameters);
    }


    /// <summary>
    ///  Simple helper extension method to marshall to correct thread if its required
    /// </summary>
    /// <param name="control"></param>
    /// <param name="methodcall"></param>
    /// <param name="priorityForCall"></param>
    /// <param name="parameters"></param>
    public static void InvokeIfRequired(this DispatcherObject control, Action<object[]> methodcall, DispatcherPriority priorityForCall, params object[] parameters) {
      // CheckAccess returns true if you're on the dispatcher thread.
      if (!control.Dispatcher.CheckAccess())
        control.Dispatcher.Invoke(priorityForCall, methodcall, parameters);
      else
        methodcall(parameters);
    }
  }
}
//  *****************************************************************************
//  File:       OSInfo.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Linq;
using System.Management;
using System.Text;

namespace TinTin.Commands {
  public partial class Switchboard {
    // ReSharper disable once InconsistentNaming
    public void OSInfo(string s) {
      var sb = new StringBuilder();
      sb.AppendLine("Operating System Information");
      sb.AppendLine("----------------------------");

      var name = (from x in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>() select x.GetPropertyValue("Caption")).FirstOrDefault();

      sb.AppendLine($"Name = {name?.ToString() ?? OSVersionInfo.Name}");
      sb.AppendLine($"BuildVersion = {OSVersionInfo.BuildVersion}");
      sb.AppendLine($"Edition = {OSVersionInfo.Edition}");
      sb.AppendLine(OSVersionInfo.ServicePack != string.Empty ? $"Service Pack = {OSVersionInfo.ServicePack}" : "Service Pack = None");
      sb.AppendLine($"Version = {OSVersionInfo.VersionString}");
      sb.AppendLine($"ProcessorBits = {OSVersionInfo.ProcessorBits}");
      sb.AppendLine($"OSBits = {OSVersionInfo.OSBits}");
      sb.AppendLine($"ProgramBits = {OSVersionInfo.ProgramBits}");

      Program.Print(sb.ToString());
    }
  }
}
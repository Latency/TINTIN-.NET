// *****************************************************************************
// File:      OSInfo.cs
// Solution:  TinTin.NET
// Date:      10/20/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Linq;
using System.Text;
using System.Management;

namespace TinTin.Commands {
  public partial class Switchboard {
    // ReSharper disable once InconsistentNaming
    public void OSInfo(string s) {
      var sb = new StringBuilder();
      sb.AppendLine("Operating System Information");
      sb.AppendLine("----------------------------");
      
      var name = (from x in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>()
                  select x.GetPropertyValue("Caption")).FirstOrDefault();

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
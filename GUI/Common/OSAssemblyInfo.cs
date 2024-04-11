//  *****************************************************************************
//  File:      OSAssemblyInfo.cs
//  Solution:  Sentinel
//  Project:   Common
//  Date:      07/25/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System;
using System.IO;

namespace TinTin.GUI.Common {
  // ReSharper disable once InconsistentNaming
  public static class OSAssemblyInfo {
    public static bool IsManagedAssembly(Stream stream) {
      var dataDictionaryRva = new uint[16];
      var dataDictionarySize = new uint[16];

      var reader = new BinaryReader(stream);

      //PE Header starts @ 0x3C (60). Its a 4 byte header.
      stream.Position = 0x3C;
      var peHeader = reader.ReadUInt32();

      //Moving to PE Header start location...
      stream.Position = peHeader;
      var peHeaderSignature = reader.ReadUInt32();

      // Limiting to the CLI header test.
      // https://blogs.msdn.microsoft.com/kstanton/2004/03/31/exploring-pe-file-headers-using-managed-code/
      var machine = reader.ReadUInt16();
      var sections = reader.ReadUInt16();
      var timestamp = reader.ReadUInt32();
      var pSymbolTable = reader.ReadUInt32();
      var noOfSymbol = reader.ReadUInt32();
      var optionalHeaderSize = reader.ReadUInt16();
      var characteristics = reader.ReadUInt16();

      // Now we are at the end of the PE Header and from here, the PE Optional Headers starts...
      // To go directly to the datadictionary, we'll increase the stream’s current position to with 96 (0x60). 96 because,
      // 28 for Standard fields 68 for NT-specific fields From here DataDictionary starts...and its of total 128 bytes.
      //
      // DataDictionay has 16 directories in total, doing simple maths 128/16 = 8. So each directory is of 8 bytes.
      // In this 8 bytes, 4 bytes is of RVA and 4 bytes of Size. btw, the 15th directory consist of CLR header! if its 0, its not a CLR file.
      var dataDictionaryStart = Convert.ToUInt16(Convert.ToUInt16(stream.Position) + 0x60);
      stream.Position = dataDictionaryStart;
      for (var i = 0; i < 15; i++) {
        dataDictionaryRva[i] = reader.ReadUInt32();
        dataDictionarySize[i] = reader.ReadUInt32();
      }

      return dataDictionaryRva[14] != 0;
    }
  }
}
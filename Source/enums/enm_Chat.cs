// *****************************************************************************
// File:      enm_Chat.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

namespace TinTin.Enums {
  public enum Chat {
    NameChange,
    RequestConnections,
    ConnectionList,
    TextEverybody,
    TextPersonal,
    TextGroup,
    Message,
    DoNotDisturb,
    SendAction,
    SendAlias,
    SendMacro,
    SendVariable,
    SendEvent,
    SendGag,
    SendHighlight,
    SendList,
    SendArray,
    SendBaritem,
    Version,
    FileStart,
    FileDeny,
    FileBlockRequest,
    FileBlock,
    FileEnd,
    FileCancel,
    PingRequest,
    PingResponse,
    PeekConnections,
    PeekList,
    SnoopStart,
    SnoopData,
    EndOfCommand = 255
  }
}
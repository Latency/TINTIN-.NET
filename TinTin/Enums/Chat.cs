//  *****************************************************************************
//  File:       Chat.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

namespace TinTin.Enums {
  public enum Chat {
    NameChange = 1,
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
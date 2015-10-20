﻿// *****************************************************************************
// File:      ICommands.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

// ReSharper disable InconsistentNaming
namespace TinTin.Interfaces {
  internal interface ICommands {
    void Action(string str);
    void Alias(string str);
    void All(string str);
    void Bell(string str);
    void Break(string str);
    void Buffer(string str);
    void Case(string str);
    void Chat(string str);
    void Chat_Protocol(string str);
    void Class(string str);
    void Colors(string str);
    void Commands(string str);
    void Config(string str);
    void Continue(string str);
    void Cr(string str);
    void Cursor(string str);
    void Debug(string str);
    void Default(string str);
    void Delay(string str);
    void Echo(string str);
    void Else(string str);
    void Elseif(string str);
    void End(string str);
    void Escape_Codes(string str);
    void Event(string str);
    void Forall(string str);
    void Foreach(string str);
    void Format(string str);
    void Function(string str);
    void Gag(string str);
    void Greeting(string str);
    void Grep(string str);
    void Help(string str);
    void Highlight(string str);
    void History(string str);
    void If(string str);
    void Ignore(string str);
    void Info(string str);
    void Keypad(string str);
    void Kill(string str);
    void Line(string str);
    void List(string str);
    void Log(string str);
    void Loop(string str);
    void Macro(string str);
    void Map(string str);
    void Math(string str);
    void MathExp(string str);
    void Message(string str);
    void Name(string str);
    void Nop(string str);
    void OSInfo(string str);
    void Parse(string str);
    void Path(string str);
    void PathDir(string str);
    void Prompt(string str);
    void Read(string str);
    void RegExp(string str);
    void Repeat(string str);
    void Replace(string str);
    void Return(string str);
    void Run(string str);
    void Scan(string str);
    void Script(string str);
    void Send(string str);
    void Session(string str);
    void Showme(string str);
    void Snoop(string str);
    void Speedwalk(string str);
    void Split(string str);
    void Substitute(string str);
    void Suspend(string str);
    void Switch(string str);
    void System(string str);
    void Tab(string str);
    void Textin(string str);
    void Ticker(string str);
    void UnGag(string str);
    void UnTab(string str);
    void Variable(string str);
    void While(string str);
    void Wildcards(string str);
    void Write(string str);
    void WriteBuffer(string str);
    void Zap(string str);
  }
}
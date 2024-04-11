# TinTin#

---

 A terminal screen-scraping client enhanced with features for various communication protocols such as telnet/ssh/etc.
 Serves as a macro pre-processor and proprietary interpreter based scripting language.
 Includes Peer-To-Peer chat relay.

## This project is currently under construction!

---

* CREATED BY: Latency McLaughlin
* FRAMEWORK:  .NET Core 2.0
* SUPPORTS:   Visual Studio, DotGNU, Rider, MonoDevelop, etc.
* UPDATED:    10/9/2017
* TAGS:       C# .NET TinTin TinTin++ TinTin# Client Interpreter
* VERSION:    v3.0.0

<hr>

## Navigation
* <a href="#introduction">Introduction</a>
* <a href="#history">History</a>
* <a href="#about">About</a>
* <a href="#usage">Usage</a>
* <a href="#installation">Installation</a>
* <a href="#license">License</a>

<hr>

<h2><a name="introduction">Introduction</a></h2>

TinTin++ is a MUD client primarily written for Unix-like systems and is now available for multi-platform use.
It is one of the oldest MUD clients in existence and a successor of the TINTIN(++) client.

According to its author, TINTIN stands for "The kIckiN Tickin dIkumud clieNt".

<h2><a name="history">History</a></h2>

TINTIN originated as a single file containing 700 lines of C code, allowing triggers and aliases, that was posted on Usenet by Peter Unold on April 1, 1992.
On October 6 1992 Peter Unold made his final release, TINTIN III, which was a much more matured and feature rich program.

In 1993 the development of TINTIN was continued by Bill Reiss who announced the release of TinTin++ v1.0 on July 3, 1993.
On April 25, 1994 TinTin++ 1.5 was announced, which was a joint effort by Bill Reiss, David A. Wagner, Rob Ellsworth, and Jeremy C. Jack.

After the 1.5 release in 1994 active development came to a halt. TinTin++ 1.5 had gained significant popularity however, and being public domain this resulted
in many derivative works like zMUD, yTin, Lyntin, Pueblo, WinTin95, and GGMud.

In 1998 development was continued briefly by Rob Elsworth who incorporated several patches by Sverre Normann before handing over development to Davin Chan who
re-licensed the software to GNU GPL on July 12th, 2001 in his final release of TinTin++ 1.86b.

In 2004 development was continued by Igor van den Hoven.

In 2017 development was continued by Latency McLaughlin and had ported it to .NET Core in C# as a universal platform for all and a complete re-write and overhaul
consoladating several systems and making things easier to use.

<h2><a name="about">About</a></h2>

TinTin# is a console telnet client enhanced with features that work particularly well for playing MUDs,
though it allows connecting to Linux and Bulletin Board System servers as well.

To enhance game play on MUDs, the client can create a split screen arrangement, which divides the interface
into input, output, and status areas. Input handling is enhanced with readline-like input editing, macro,
and alias support. Text received from the server can be highlighted or set to execute triggers written in
the TINTIN scripting language, which resembles the C/C++/C#/Java programming languages.

TinTin# has various other features that are commonly found in modern MUD clients, such as automapping, MCCP,
friend-to-friend messaging, logging in HTML, and a TELNET event handler.

<h2><a name="usage">Usage</a></h2>

<b>Supported Protocols</b>
<table>
   <tr>
      <td>Character Mode</td>
      <td>Directly transmit the mud client's input, required for BBSes, *NIX servers, and Roguelike MUDs.</td>
   </tr>
   <tr>
      <td>GMCP</td>
      <td>Generic Mud Communication Protocol.</td>
   </tr>
   <tr>
      <td>Go Ahead</td>
      <td>Allows the server to indicate the end of output for better mud client side prompt handling.</td>
   </tr>
   <tr>
      <td>IPv6</td>
      <td>Allows 128-bit IP addresses.</td>
   </tr>
   <tr>
      <td>MCCP</td>
      <td>Mud Client Compression Protocol.</td>
   </tr>
   <tr>
      <td>MSDP</td>
      <td>Mud Server Data Protocol.</td>
   </tr>
   <tr>
      <td>MSSP</td>
      <td>Mud Server Status Protocol.</td>
   </tr>
   <tr>
      <td>MudMaster Chat</td>
      <td>Instant messaging and file transfers over private P2P connections.</td>
   </tr>
   <tr>
      <td>NAWS</td>
      <td>Sends the mud client's window size to the server.</td>
   </tr>
   <tr>
      <td>Regular Expressions</td>
      <td>Use powerful Perl Compatible Regular Expressions in triggers and commands.</td>
   </tr>
   <tr>
      <td>TELNET</td>
      <td>Connect to *NIX servers and BBSes using TELOPT negotiations.</td>
   </tr>
   <tr>
      <td>VT100</td>
      <td>Displays both mud client and server side text interfaces.</td>
   </tr>
   <tr>
      <td>xterm 256 colors</td>
      <td>Highlight in 256 colors instead of the traditional 16 colors.</td>
   </tr>
</table>
<hr>
<b>Program Features</b>
<table>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Action.txt">Action</a></td>
      <td>Triggers a script when a matching line of text is found.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Alias.txt">Alias</a></td>
      <td>Allows command shortcuts bundling multiple commands together.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/All.txt">All</a></td>
     <td>Execute commands across multiple sessions.</td>
   </tr>
   <tr>
      <td>Associative Arrays</td>
      <td>Fast and flexible variable system using nested associative arrays.</td>
   </tr>
   <tr>
      <td>Auto Mapper</td>
      <td>Creates an interactive map to help visualize and navigate the game world.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Bell.txt">Bell</a></td>
     <td>Rings the terminal bell.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Buffer.txt">Buffer</a></td>
     <td>Manipulates the scrollback buffer.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Class.txt">Class</a></td>
      <td>Labels a set of triggers to belong to a given class which allows removing or saving them independently.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Chat.txt">Chat</a></td>
     <td>Used to create peer to peer connections to other clients.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Chat_Protocol.txt">Chat_Protocol</a></td>
     <td>Inter-mud chat protocols.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Colors.txt">Colors</a></td>
     <td>Displays the color list and attributes for the terminal.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Config.txt">Config</a></td>
     <td>Displays the environment variables used by the client and offers re-assignments to them if specified.</td>
   </tr>
   <tr>
      <td>Control Flow</td>
      <td>Uses braces for nesting,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Break.txt">Break</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Case.txt">Case</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Continue.txt">Continue</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Default.txt">Default</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/If.txt">If</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Else.txt">Else</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Elseif.txt">Elseif</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Forall.txt">Forall</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Foreach.txt">Foreach</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Loop.txt">Loop</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Return.txt">Return</a>,
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Switch.txt">Switch</a>, and
        <a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/While.txt">While</a> statements,
        allowing C-like programming.
      </td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Cr.txt">Cr</a></td>
     <td>Carriage return.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Cursor.txt">Cursor</a></td>
     <td>Adds customizable input editing with macros.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Debug.txt">Debug</a></td>
      <td>Enables the debugging mode giving useful information for finding bugs in your scripts.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Delay.txt">Delay</a></td>
      <td>Executes a script after a set amount of seconds has passed.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Echo.txt">Echo</a></td>
     <td>Echos a string verbatim.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/End.txt">End</a></td>
     <td>Terminates the process and closes all sessions.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Escape_Codes.txt">Escape_Codes</a></td>
     <td>Displays the list of escape codes available.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Event.txt">Event</a></td>
      <td>Executes a script when an event occurs.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Format.txt">Format</a></td>
      <td>Formats text using a printf like syntax.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Function.txt">Function</a></td>
      <td>Executes a script and substitutes the function call with the return value.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Gag.txt">Gag</a></td>
      <td>Prevents lines of text from being displayed.  Alias for #substitute {message} {<empty>}</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Greeting.txt">Greeting</a></td>
     <td>A greeting message to be specified or overridden.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Grep.txt">Grep</a></td>
      <td>Searches and displays matching lines in the scrollback buffer.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Help.txt">Help</a></td>
     <td>Displays documentation for a given command or displays the list as a collection if no argument was specified.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Highlight.txt">Highlight</a></td>
      <td>Changes the color of incoming text.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/History.txt">History Buffer</a></td>
      <td>Stores the last commands you typed. Press UP to scroll through the list, or ctrl-r to find matches.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Ignore.txt">Ignore</a></td>
     <td>Toggles verbatim all the nodes associated per list type specified that were registered.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Info.txt">Info</a></td>
     <td>Displays the amount of nodes per list type registered.</td>
   </tr>
   <tr>
      <td>Input editing</td>
      <td>Input editing and handling that is almost identical to the Linux shell.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Keypad.txt">Keypad</a></td>
     <td>Keypad configuration layout.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Kill.txt">Kill</a></td>
     <td>Iterates the command specified and removes registered statements associated.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Line.txt">Line</a></td>
     <td>Redirects control of the output line being sent as a pre-trigger.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/List.txt">Lists</a></td>
      <td>Stores information as a list instead of as an associative array.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Log.txt">Log</a></td>
      <td>Logs incoming data as HTML, VT100, or plain text.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Macro.txt">Macro</a></td>
      <td>Assigns commands to any possible key combination.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Map.txt">Map</a></td>
     <td>Used for the auto-mapper.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Math.txt">Math</a></td>
      <td>Uses 64 bit floating point arithmatic and logical expressions.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Mathexp.txt">Mathexp</a></td>
     <td>Mathematical expressions are used for calculations and boolean if checks.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Message.txt">Message</a></td>
     <td>Toggles output being sent verbatim for individual commands.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Name.txt">Name</a></td>
     <td>Uses the session name unique to the running session as a macro which was appended to the command list.  Renders context switching or indirect session command execution.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Nop.txt">Nop</a></td>
     <td>No operation statement.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/OSInfo.txt">OSInfo</a></td>
     <td>Retrieves operating system information.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Parse.txt">Parse</a></td>
     <td>Works similarly to a LINQ aggregate statement.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Path.txt">Path</a></td>
     <td>Records movements and creates a list of commands to move from one location to another.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Pathdir.txt">Pathdir</a></td>
     <td>Bitvectored cardinal direction configuration macros.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Prompt.txt">Prompt</a></td>
      <td>Captures lines and places them on the split line for the creation of status bars.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Session.txt">Session</a></td>
      <td>Opens one or multiple sessions to connect to a server.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Read.txt">Read</a></td>
      <td>Reads in a script file. Script code can be indented and spaced out over several lines.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Regexp.txt">Regexp</a></td>
     <td>Used to compare the given string to the given regular expression.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Repeat.txt">Repeat</a></td>
     <td>Repeats the same command multiple times.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Replace.txt">Replace</a></td>
     <td>Searchs the variable for the given string in oldtext and replace it with the string given in newtext.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Run.txt">Run</a></td>
      <td>Runs a given application, such as ssh, or sftp, with access to all of TinTin++'s scripting capabilities.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Scan.txt">Scan</a></td>
      <td>Reads in an ANSI or plain text log file so you can view it in the scrollback buffer.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Script.txt">Script</a></td>
      <td>Runs the given script written in bash, lua, perl, php, python, ruby, etc, storing the output as a variable or processing it as a command.</td>
   </tr>
   <tr>
      <td>Scrollback</td>
      <td>Stores up to one million lines of text which can be viewed using page-up/down.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Send.txt">Send</a></td>
     <td>Sends the text directly to the terminal.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Showme.txt">Showme</a></td>
     <td>Displays the registered statements or greps those when argument is specified.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Snoop.txt">Snoop</a></td>
     <td>Displays output from multiple sessions active uniquely specified.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Speedwalk.txt">Speedwalk</a></td>
     <td>Builds an array of cardinal directions specified with semi-colon delimiter and executes the unrolling.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Split.txt">Split Screen</a></td>
      <td>Splits the screen in an input, output, and status area.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Substitute.txt">Substitute</a></td>
      <td>Matches text or patterns and replaces them with a substitute text.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Suspend.txt">Suspend</a></td>
     <td>Suspends the process to give control back to the shell.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Switchboard.txt">Switchboard</a></td>
     <td>Iterates the commands registered, including macros auto-generated.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/System.txt">System</a></td>
     <td>Execute commands from the shell.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Tab.txt">Tab Completion</a></td>
      <td>Recalls hard to spell words by typing the first couple of letters and pressing tab till the right match shows up. By default the scrollback buffer is used for tabbing.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Textin.txt">Textin</a></td>
     <td>Reads in a script file to be ammended globally.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Ticker.txt">Ticker</a></td>
     <td>Asynchronous trigger with timeout to execute statements.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/UnTab.txt">UnTab</a></td>
     <td>Removes the completion word from the tab completion list.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Variable.txt">Variable</a></td>
     <td>Variables are global for each session and can be accessed by adding a $ before the variable name.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Wildcards.txt">Wildcards</a></td>
     <td>Used for string match searches using regular expressions.</td>
   </tr>
   <tr>
      <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Write.txt">Write</a></td>
      <td>Write out scripts that are automatically indented, making scripts easy to read and debug.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Writebuffer.txt">Writebuffer</a></td>
     <td>Writes the scrollback buffer to file.</td>
   </tr>
   <tr>
     <td><a href="https://github.com/Latency/TINTIN-.NET/blob/master/Source/Help/Zap.txt">Zap</a></td>
     <td>Closes the active session. If no session is active it will terminate the program.</td>
   </tr>
</table>

## Shortcut Guide

| Shortcut                       | Comment                           |
| ------------------------------ | --------------------------------- |
| `Ctrl`+`A` / `HOME`            | Beginning of line                 |
| `Ctrl`+`B` / `←`               | Backward one character            |
| `Ctrl`+`C`                     | Send EOF                          |
| `Ctrl`+`E` / `END`             | End of line                       |
| `Ctrl`+`F` / `→`               | Forward one character             |
| `Ctrl`+`H` / `Backspace`       | Delete previous character         |
| `Tab`                          | Command line completion           |
| `Shift`+`Tab`                  | Backwards command line completion |
| `Ctrl`+`J` / `Enter`           | Line feed                         |
| `Ctrl`+`K`                     | Cut text to the end of line       |
| `Ctrl`+`L`                     | Clear line                        |
| `Ctrl`+`M`                     | Same as Enter key                 |
| `Ctrl`+`N` / `↓`               | Forward in history                |
| `Ctrl`+`P` / `↑`               | Backward in history               |
| `Ctrl`+`U`                     | Cut text to the start of line     |
| `Ctrl`+`W`                     | Cut previous word                 |
| `Backspace`                    | Delete previous character         |
| `Delete`                       | Delete succeeding character       |

<h2><a name="installation">Installation</a></h2>

This library can be installed using NuGet:

<pre>
Name:    TinTin#
Source:  nuget.org
</pre>

<h2><a name="license">License</a></h2>

[GNU LESSER GENERAL PUBLIC LICENSE] - Version 3, 29 June 2007


[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job.)

   [GNU LESSER GENERAL PUBLIC LICENSE]: <http://www.gnu.org/licenses/lgpl-3.0.en.html>

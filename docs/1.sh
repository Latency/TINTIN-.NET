#!/bin/sh


for name in \
"Alias" \
"All" \
"Bell" \
"Break" \
"Buffer" \
"Case" \
"Chat" \
"Chat_Protocol" \
"Class" \
"Colors" \
"Commands" \
"Config" \
"Continue" \
"Cr" \
"Cursor" \
"Debug" \
"Default" \
"Delay" \
"Echo" \
"Else" \
"Elseif" \
"End" \
"Escape_Codes" \
"Event" \
"Forall" \
"Foreach" \
"Format" \
"Function" \
"Gag" \
"Greeting" \
"Grep" \
"Help" \
"Highlight" \
"History" \
"If" \
"Ignore" \
"Info" \
"Keypad" \
"Kill" \
"Line" \
"List" \
"Log" \
"Loop" \
"Macro" \
"Map" \
"Math" \
"Mathexp" \
"Message" \
"Name" \
"Nop" \
"Parse" \
"Path" \
"Pathdir" \
"Prompt" \
"Read" \
"Regexp" \
"Repeat" \
"Replace" \
"Return" \
"Run" \
"Scan" \
"Script" \
"Send" \
"Session" \
"Showme" \
"Snoop" \
"Speedwalk" \
"Split" \
"Substitute" \
"Suspend" \
"Switch" \
"System" \
"Tab" \
"Textin" \
"Ticker" \
"Variable" \
"While" \
"Wildcards" \
"Write" \
"Writebuffer" \
"Zap"
do
 echo "• <a href=\"./docs/$name.txt\">$name</a>" >> 1.txt
done

exit 0
/*****************************************************************************
 * File:     color.cpp
 * Engineer: Matt McLaughlin                           Bio-Hazard Industries *
 * Date:     07/26/00                          ©1994  ¯  All Rights Reserved *
 * Usage:                                                                    *
 ****************************************************************************/
#include "color.hpp"
#include <ctypes.hpp>


std::string::size_type ParseColor(std::string & temp, const std::string & input)
{
  std::string str = input;
  // Main buffer.
  temp.clear();
  // Used for &+ &-
  char *ptr, nibble[4];
  bool verbatim = false, is_color = false;
  // Common variable
  ushort x = 0, bit;
  int y = 0;

  while (str[x]) {
	if (str[x] == '\\') {		// Toggle verbatim mode
	  verbatim = !verbatim;
	  if (str[++x] == '\\') {
		verbatim = !verbatim;
		temp += str[x];
	  } else
		x--;
	} else if (!verbatim && str[x] == '&') {
	  switch (str[++x]) {
		case '+':
		case '-':
		case '=':
		  if (str[x] == '+')
			bit = 2;
		  else if (str[x] == '-')
			bit = 1;
		  else
			bit = 0;
		  if ((ptr = index("01234567", str[++x]))) {
			temp += "[";
			temp += (bit == 2 ? '3' : (bit == 0 ? : '4'));
			temp += ptr[0];
			temp += 'm';
			is_color = true;
		  } else {
			x -= 2;
			temp += str[x];
		  }
		  break;

		case '~':
		  x++;
		  strncpy(nibble, (str.c_str() + x), 3);
		  nibble[3] = '\0';
		  if (IsNumber(nibble) && (y = atoi(nibble)) < 256) {
			temp += (u_char) y;
			x += 2;
		  } else {
			x -= 2;
			temp += str[x];
		  }
		  break;

		default:
		  temp += str[--x];
		  break;
	  }
	} else if (is_color && str[x] == '\n') {
	  verbatim = false;
	  is_color = false;
	  temp += "[0m\n";
	} else
	  temp += str[x];
	x++;
  }
  return temp.length();
}

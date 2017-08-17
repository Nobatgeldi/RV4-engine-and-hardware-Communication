// Nobat_ext.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
#include "Nobat_ext.h" 
#include <iostream>
#include <cstring>
#include <string>
#include <vector>
#include <iterator>
#include <sstream>

using namespace std;
using namespace Nobat_ext;
 
#using <System.dll>
using namespace System;
using namespace System::IO::Ports;
using namespace System::Threading;

//void serial(const char *axis);
#define CURRENT_VERSION "0.1"

extern "C"
{
	//--- Engine called on extension load 
	__declspec (dllexport) void __stdcall RVExtension(char *output, int outputSize, const char *function);
	//--- STRING callExtension STRING
	__declspec (dllexport) void __stdcall RVExtension(char *output, int outputSize, const char *function);
	//--- STRING callExtension ARRAY
	//__declspec (dllexport) int __stdcall RVExtensionArgs(char *output, int outputSize, const char *function, const char **args, int argsCnt);

}
//--- Extension version information shown in .rpt file
void __stdcall RVExtensionVersion(char *output, int outputSize)
{
	//--- max outputSize is 32 bytes
	strncpy_s(output, outputSize, CURRENT_VERSION, _TRUNCATE);
}

void __stdcall RVExtension(char *output, int outputSize, const char *function)
{
	outputSize -= 1;
	if (!strcmp(function, "version"))
	{
		strncpy(output, "1.0", outputSize);
	}
	else
	{
		Functions ben;
		strncpy(output, "connected", outputSize);
		int a = ben.Serial(function);
	}
}


namespace Nobat_ext
{
	char Functions::Serial(const char *axis)
	{
		
		SerialPort^ mySerialPort = gcnew SerialPort("COM4");
		mySerialPort->BaudRate = 115200;
		//mySerialPort->Open();
		if (!mySerialPort->IsOpen)
		{

			mySerialPort->Open();
			if (!strcmp(axis, "y"))
			{
				mySerialPort->Write("y");
				//std::cin.get();
			}
			else if (!strcmp(axis, "x"))
			{
				mySerialPort->Write("x");
				//std::cin.get();
			}
			else if (!strcmp(axis, "z"))
			{
				mySerialPort->Write("z");
				//std::cin.get();
			}
			else
			{
				mySerialPort->Write("2");
			}
			mySerialPort->Close();
			return 'o';
		}
		else
		{
			if (!strcmp(axis, "120"))
			{
				mySerialPort->Write("2");
				//std::cin.get();
			}
			else
			{
				mySerialPort->Write("2");
			}
			return 'c';
		}
			
		//string str = string("nobat");
	}
}
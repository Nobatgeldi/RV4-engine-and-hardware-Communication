// arma_serial_test.cpp : Defines the entry point for the console application.

#include "stdafx.h"  
#include <iostream>  
#include "Nobat_ext.h"


using namespace std;
using namespace Nobat_ext;

int main()
{
	const char *a = "y";
	const char * b = "x";
	const char * c = "z";
	const char * e = "1";
	Functions serial;
	int d = 1;
	cout << serial.Serial("2") << endl;
	while (true)
	{
		cin >> d;
		cout <<  serial.Serial(a) << endl;
		cin >> d;
		cout <<  serial.Serial(b) << endl;
		cin >> d;
		cout << serial.Serial(c) << endl;
		cin >> d;
		cout << serial.Serial(e) << endl;
	}
	
	return 0;
}

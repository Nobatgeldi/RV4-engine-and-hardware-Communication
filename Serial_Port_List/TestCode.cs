// File: TestCode.cs  

using System;
using System.IO.Ports;

namespace Serial_Port
{
    class Serial_Port
    {
        public static void Main()
        {
            Console.WriteLine(CalculateArea("nobat"));
            Console.ReadLine();
        }
        static string CalculateArea(String r)
        {
            string[] ports = SerialPort.GetPortNames();
            string output = "";
            foreach (string port in ports)
            {
                output = output + port + "/";
            }
            return output;
        }
    }
}
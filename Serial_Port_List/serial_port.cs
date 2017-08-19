using RGiesecke.DllExport;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO.Ports;

namespace Serial_Port
{
    public class Serial_Port_List
    {
        [DllExport("RVExtension", CallingConvention = CallingConvention.Winapi)]
        public static void RvExtension(StringBuilder output, int outputSize, [MarshalAs(UnmanagedType.LPStr)] string function)
        {
            outputSize--;
            string result = "Free";
            if (function == "connection")
            {
                result = Connection(function);
            }
            else
            {
                result = "version 0.1";
            }
            output.Append(result);
        }

        public static string Connection(String r)
        {
            string[] ports = SerialPort.GetPortNames();
            string output = "";
            foreach (string port in ports)
            {
                output = output + port + "/";
            }
            return output;
        }

        public static string Send_Data(String axis)
        {
            string COM = "";

            string y_axis = "";
            string x_axis = "";
            string z_axis = "";

            String[] substrings;
            Char delimiter = '/';
            substrings = axis.Split(delimiter);

            if (axis.Contains("COM"))
            {
                COM = substrings[0].ToString();

                y_axis = substrings[1].ToString();
                x_axis = substrings[2].ToString();
                z_axis = substrings[3].ToString();
            }
            else
            {
                y_axis = substrings[0].ToString();
                x_axis = substrings[1].ToString();
                z_axis = substrings[2].ToString();

            }
            Console.WriteLine(COM);
            Console.WriteLine(y_axis);
            Console.WriteLine(x_axis);
            Console.WriteLine(z_axis);
            SerialPort connection = new SerialPort(COM, 115200);
            try
            {
                connection.Open();
            }
            catch
            {
                Console.WriteLine("Something happened :(");
            }
            if (connection.IsOpen)
            {
                if (y_axis.Length != 0)
                {
                    connection.Write("Y");
                }
                if (x_axis.Length != 0)
                {
                    connection.Write("x");
                }
                if (z_axis.Length != 0)
                {
                    connection.Write("z");
                }
                else
                {
                    connection.Write("1");
                }
                connection.Close();
            }
            else
            {
                connection.Open();
            }
            return axis;
        }
    }
}

using RGiesecke.DllExport;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO.Ports;

namespace Serial_Port
{
    public class Serial_Port_List
    {
        static string COM_IN = "COM4";
        [DllExport("RVExtension", CallingConvention = CallingConvention.Winapi)]
        public static void RvExtension(StringBuilder output, int outputSize, [MarshalAs(UnmanagedType.LPStr)] string function)
        {
            outputSize--;
            string result = "Free";
            if (function == "serial_ports")
            {
                result = Serial_Ports(function);
            }
            else
            {
                if (function.Contains("COM"))
                {
                    //Console.WriteLine("burdayih");
                    result = Test_Connection(function); 
                }
                else
                {
                    result = Send_Data(function);
                }
            }
            output.Append(result);
        }

        public static string Serial_Ports(String r)
        {
            string[] ports = SerialPort.GetPortNames();
            string output = "";
            foreach (string port in ports)
            {
                output = output + port + "/";
            }
            return output;
        }
        public static string Test_Connection(String COM)
        {
            string succeed = "succeed";
            string failed = "failed";
            SerialPort connection = new SerialPort(COM, 115200);
            try
            {
                connection.Open();
                connection.Write("L");
                connection.Close();
                COM_IN = COM;
                return succeed;
            }

            catch (Exception e)
            {
                //Console.WriteLine(failed);
                return failed;
            }
        }

        public static string Send_Data(String axis)
        {
            string COM = COM_IN;

            string y_axis = "";
            string x_axis = "";
            string z_axis = "";

            String[] substrings;
            Char delimiter = '/';
            substrings = axis.Split(delimiter);

            y_axis = substrings[0].ToString();
            x_axis = substrings[1].ToString();
            z_axis = substrings[2].ToString();

            /*Console.WriteLine(COM);
            Console.WriteLine(y_axis);
            Console.WriteLine(x_axis);
            Console.WriteLine(z_axis);*/
            SerialPort connection = new SerialPort(COM, 115200);
            try
            {
                connection.Open();
                //connection.Write("y");
                if (y_axis.Length != 0)
                {
                    connection.Write("y");
                    Console.WriteLine("Y");
                }
                /*if (x_axis.Length != 0)
                {
                    connection.Write("x");
                    Console.WriteLine("X");
                }
                /*if (z_axis.Length != 0)
                {
                    connection.Write("z");
                    Console.WriteLine("Z");
                }
                else
                {
                    connection.Write("1");
                }*/
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something happened :(");
            }
            return axis;
        }
    }
}

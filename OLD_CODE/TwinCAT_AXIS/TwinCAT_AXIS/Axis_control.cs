using System;
using System.Text;
using TwinCAT.Ads;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;

namespace TwinCAT_AXIS
{
    public class Axis_control
    {
        private static int varHandle;
        private TcAdsClient adsClient;
        static bool r = false;

        [DllExport("RVExtension", CallingConvention = CallingConvention.Winapi)]
        public static void RvExtension(StringBuilder output, int outputSize, [MarshalAs(UnmanagedType.LPStr)] string function)
        {
            outputSize--;
            Axis_control var = new Axis_control();
            string result = "Free";

            #region String
                string y_axis = ""; string x_axis = ""; string z_axis = "";

                String[] substrings;
                Char delimiter = '/';

                substrings = function.Split(delimiter);

                y_axis = substrings[0].ToString();
                x_axis = substrings[1].ToString();
                z_axis = substrings[2].ToString();
                //Console.WriteLine(x_axis);
            #endregion

            if (var.Connect())
            {
                var.Write(x_axis);
                //var.Close();
            }
            else
            {
                result = "There is/are problem(s)";
            }
            output.Append(result);
        }

        private bool Connect()
        {
            adsClient = new TcAdsClient();
            Axis_control var = new Axis_control();
            try
            {
                // PLC1 Port: TwinCAT2=801, TwinCAT3=851
                adsClient.Connect("5.50.205.46.1.1", 801);
                varHandle = adsClient.CreateVariableHandle(".input");
                r = true;
            }
            catch 
            {
                r = false;
            }
            return r;
        }

        private string Read()
        {
            String output="";
            try
            {
                AdsStream adsStream = new AdsStream(30);
                AdsBinaryReader reader = new AdsBinaryReader(adsStream);
                //output = adsClient.ReadAny(varHandle, typeof(int)).ToString();

                adsClient.Read(varHandle, adsStream);
                output = reader.ReadPlcAnsiString(35);
                //Console.WriteLine(output);
            }
            catch (Exception err)
            {
                output = err.ToString();
            }
            return output;
        }

        private int Write(string input)
        {
            /*String input;
            int input_2;*/
            try
            {
                AdsStream adsStream = new AdsStream(30);
                AdsBinaryWriter writer = new AdsBinaryWriter(adsStream);
                adsClient.WriteAny(varHandle, input, new int[] {35});
                //adsClient.WriteAny(varHandle, input);
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
            return 0;
        }

        public void Close()
        {
            adsClient.Dispose();
        }
    }
}

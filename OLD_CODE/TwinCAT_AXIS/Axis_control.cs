using System;
using System.IO;
using System.Text;
using System.Collections;
using TwinCAT.Ads;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;

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

            string y_axis = ""; string x_axis = ""; string z_axis = "";

            String[] substrings;
            Char delimiter = '/';

            substrings = function.Split(delimiter);

            y_axis = substrings[0].ToString();
            x_axis = substrings[1].ToString();
            z_axis = substrings[2].ToString();
            if (var.connect_tes())
            {

            }
            output.Append(result);
        }

        

        /*static void Main(string[] args)
        {
            Axis_control test = new Axis_control();
            //test.Test_twin();
            test.connect_tes();
            test.Read();
            Console.WriteLine("Write:(True or False)");
            test.Write();
            Console.Read();
        }*/

        public bool connect_tes()
        {
            adsClient = new TcAdsClient();
            Axis_control var = new Axis_control();
            try
            {
                // PLC1 Port: TwinCAT2=801, TwinCAT3=851
                adsClient.Connect("5.50.205.46.1.1", 801);
                varHandle = adsClient.CreateVariableHandle("Main.fUnit");
                r = true;
            }
            catch (Exception err)
            {
                r = false;
            }
            return r;
        }

        private void Read()
        {
            String output;
            try
            {
                AdsStream adsStream = new AdsStream(30);
                AdsBinaryReader reader = new AdsBinaryReader(adsStream);
                //Console.WriteLine(varHandle);
                output = adsClient.ReadAny(varHandle, typeof(int)).ToString();

                Console.WriteLine(output);
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }

        private void Write()
        {
            String input;
            int input_2;
            try
            {
                AdsStream adsStream = new AdsStream(30);
                AdsBinaryWriter writer = new AdsBinaryWriter(adsStream);
                input = Console.ReadLine();
                input_2 = int.Parse(input);
                adsClient.WriteAny(varHandle, input_2);
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }

        public void close()
        {
            adsClient.Dispose();
        }
    }
}

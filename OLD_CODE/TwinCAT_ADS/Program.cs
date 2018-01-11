using System;
using System.IO;
using System.Collections;
using TwinCAT.Ads;

namespace TwinCAT_ADS
{
    class Program
    {
        private static int varHandle;
        private TcAdsClient adsClient;
        static string r = "";

        static void Main(string[] args)
        {
            Program test = new Program();
            //test.Test_twin();
            test.connect_tes();
            test.Read();
            Console.WriteLine("Write:(True or False)");
            test.Write();
            Console.Read();
        }

        public string connect_tes()
        {
            adsClient = new TcAdsClient();
            Program var = new Program();
            try
            {
                // PLC1 Port: TwinCAT2=801, TwinCAT3=851
                adsClient.Connect("5.50.205.46.1.1", 801);
                varHandle = adsClient.CreateVariableHandle("Main.fUnit");
            }
            catch (Exception err)
            {
                //ssageBox.Show(err.Message);
                Console.Write(err);
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

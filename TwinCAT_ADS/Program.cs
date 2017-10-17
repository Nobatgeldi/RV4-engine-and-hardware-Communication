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
                varHandle = adsClient.CreateVariableHandle("Axis_contrl.JogBackwardPD");
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
            try
            {
                AdsStream adsStream = new AdsStream(30);
                AdsBinaryReader reader = new AdsBinaryReader(adsStream);
                Console.WriteLine(varHandle);
                //adsClient.Read(varHandle, adsStream);
                Console.WriteLine(adsClient.ReadAny(varHandle, typeof(Boolean)).ToString());
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }

        private void Write()
        {
            String input;
            try
            {
                AdsStream adsStream = new AdsStream(30);
                AdsBinaryWriter writer = new AdsBinaryWriter(adsStream);
                input = Console.ReadLine();
                adsClient.WriteAny(varHandle, Boolean.Parse(input));
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

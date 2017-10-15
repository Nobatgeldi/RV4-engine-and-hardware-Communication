using System;
using System.IO;
using TwinCAT.Ads;

namespace TwinCAT_ADS
{
    class Program
    {
        private static int varHandle;
        private TcAdsClient adsClient;

        static void Main(string[] args)
        {
            Console.Write("Start");
            Console.Write(connect_tes());

            Console.Read();
        }
        public static string connect_tes()
        {
            string r="";
            TcAdsClient adsClient = new TcAdsClient();
            try
            {

                // PLC1 Port: TwinCAT2=801, TwinCAT3=851

                adsClient.Connect("172.16.3.217.1.1", 801);

                /*Parameters:
                variableName: Name of the ADS variable
                */
                varHandle = adsClient.CreateVariableHandle("MAIN.neyse_ne");

                if (adsClient.Disconnect())
                {
                    //Console.Write("Connect");
                    r = adsClient.Disconnect().ToString();
                }
            }
            catch (Exception err)
            {
                //ssageBox.Show(err.Message);
                Console.Write(err);
            }
            return r;
        }

        public void close()
        {
            adsClient.Dispose();
        }

        private void Read()
        {
            try
            {
                AdsStream adsStream = new AdsStream(30);
                AdsBinaryReader reader = new AdsBinaryReader(adsStream);
                adsClient.Read(varHandle, adsStream);

                Console.Write(reader.ReadPlcString(30));
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
                writer.WritePlcString(input, 30);

                adsClient.Write(varHandle, adsStream);
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }
    }
}

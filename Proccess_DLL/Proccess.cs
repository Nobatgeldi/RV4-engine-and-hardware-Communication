using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace Proccess_DLL
{
    class Proccess
    {
        private static int x_axis;
        private static int z_axis;

        private TcAdsClient adsClient = new TcAdsClient();
        
        static bool r = false;

        static void Main(string[] args)
        {
            var running = true;
            string axis = "";

            Proccess var = new Proccess();

            while (running) // loop only for 1 client
            {
                using (var server = new NamedPipeServerStream("ARMA_PIP", PipeDirection.InOut))
                {
                    server.WaitForConnection();

                    Console.WriteLine("Açı değerleri alındı");

                    using (var pipe = new PipeStream(server))
                    {
                        //pipe.Send("Açı değerleri iletildi");

                        axis = pipe.Receive();

                        Console.WriteLine(axis);

                        server.WaitForPipeDrain();
                        server.Flush();
                    }
                }
                #region string control
                if (axis.Contains("/"))
                {
                    String[] substrings;
                    Char delimiter = '/';
                    substrings = axis.Split(delimiter);
                    if (var.Connect())
                    {
                        var.Write(substrings[0], substrings[1]);
                        //var.Close();
                    }
                    else
                    {
                        Console.WriteLine("Burda bir sorun var, Kontrol et");
                    }
                }
                #endregion
            }
            Console.WriteLine("Sunucu kapatıldı");
            Console.Read();
        }
        private bool Connect()
        {
            //adsClient = new TcAdsClient();
            try
            {
                // PLC1 Port: TwinCAT2=801, TwinCAT3=851
                adsClient.Connect("5.50.205.46.1.1", 801);
                Parallel.Invoke(
                        () =>
                        {
                            Catch_X();
                        },
                        delegate ()
                        {
                            Catch_Z();
                        }
                    );
                r = true;
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
            return r;
        }
        private void Catch_X()
        {
            try
            {
                x_axis = adsClient.CreateVariableHandle(".x_axis"); ;
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }
        private void Catch_Z()
        {
            try
            {
                z_axis = adsClient.CreateVariableHandle(".z_axis");
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }
        private string Read()
        {
            String output = "";
            try
            {
                AdsStream adsStream = new AdsStream(30);
                AdsBinaryReader reader = new AdsBinaryReader(adsStream);
                //output = adsClient.ReadAny(varHandle, typeof(int)).ToString();

                adsClient.Read(x_axis, adsStream);
                output = reader.ReadPlcAnsiString(35);
                //Console.WriteLine(output);
            }
            catch (Exception err)
            {
                output = err.ToString();
            }
            return output;
        }
        private int Write(String input_X, String input_Z)
        {
            try
            {
                Parallel.Invoke(	// Param #0 - static method
                    () =>			// Param #1 - lambda expression
                    {
                        Write_X(input_X);
                    },
                    delegate ()		// Param #2 - in-line delegate
                    {
                        Write_Z(input_Z);
                    }
                );
            }
            catch (Exception err)
            {
                Console.Write(err);
            } 
            return 0;
        }
        private int Write_X(String input_X)
        {
            try
            {
                adsClient.WriteAny(x_axis, input_X, new int[] { 35 });
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
            return 0;
        }
        private int Write_Z(String input_Z)
        {
            try
            {
                adsClient.WriteAny(z_axis, input_Z, new int[] { 35 });
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
    public class PipeStream : IDisposable
    {
        private readonly Stream _stream;
        private readonly Reader _reader;
        private readonly Writer _writer;

        public PipeStream(Stream stream)
        {
            _stream = stream;

            _reader = new Reader(_stream);
            _writer = new Writer(_stream);
        }

        public string Receive()
        {
            return _reader.ReadLine();
        }

        public void Send(string message)
        {
            _writer.WriteLine(message);
            _writer.Flush();
        }

        public void Dispose()
        {
            _reader.Dispose();
            _writer.Dispose();

            _stream.Dispose();
        }

        private class Reader : StreamReader
        {
            public Reader(Stream stream)
                : base(stream)
            {

            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(false);
            }
        }

        private class Writer : StreamWriter
        {
            public Writer(Stream stream)
                : base(stream)
            {

            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(false);
            }
        }
    }
}

using System;
using Maca134.Arma.DllExport;
using System.IO;
using System.IO.Pipes;

namespace SM_Client_NM
{
    public class SM_Client
    {
        public static String output = "free";

        [ArmaDllExport]
        public static string Invoke(string input, int size)
        {
            

            SM_Client send = new SM_Client();
            try
            {
                output = send.SendData(input);
            }
            catch
            {
                output = "does not send";
            }
            return output;
        }
        public string SendData(string input)
        {
            try
            {
                using (var client = new NamedPipeClientStream(".", "ARMA_PIP", PipeDirection.InOut))
                {
                    client.Connect(25);

                    using (var pipe = new PipeStream(client))
                    {
                        //output = pipe.Receive();

                        pipe.Send(input);
                    }
                    client.Dispose();
                    client.Close();
                }
            }
            catch (Exception exs)
            {
                output = exs.ToString();
            }
            return output;
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

        public class Reader : StreamReader
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

        public class Writer : StreamWriter
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

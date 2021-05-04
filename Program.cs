using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CommandsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0) { // server code:
                var listener = new TcpListener(IPAddress.Any, 4444);
                listener.Start();
                var client = listener.AcceptTcpClient();
                var stream = client.GetStream();
                using var writer = new StreamWriter(stream);
                writer.Write("Hello World!");
            }
            else
            { // client code: 
                var client = new TcpClient(new IPEndPoint(IPAddress.Any, 4445));
                client.Connect(IPAddress.Loopback, 4444);
                var stream = client.GetStream();
                var response = new StreamReader(stream).ReadToEnd();
                Console.WriteLine(response);
            }
        }
    }
}

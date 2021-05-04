using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CommandsSample
{
    public class Server : Command {
        protected override string Name => "server";
        protected override void DoRun() {
            var listener = new TcpListener(IPAddress.Any, 4444);
            listener.Start();
            var client = listener.AcceptTcpClient();
            var stream = client.GetStream();
            using var writer = new StreamWriter(stream);
            writer.Write("Hello World!");
        }
    }

    public class Client : Command {
        protected override string Name => "client";
        protected override void DoRun() {
            var client = new TcpClient(new IPEndPoint(IPAddress.Any, 4445));
            client.Connect(IPAddress.Loopback, 4444);
            var stream = client.GetStream();
            var response = new StreamReader(stream).ReadToEnd();
            Console.WriteLine(response);
        }
    }
    
    public abstract class Command {
        protected abstract string Name { get; }
        protected abstract void DoRun();
        public void Run(string[] args) {
            if(args[0] == this.Name) 
            {
                Console.WriteLine($"Starting {this.Name}...");
                DoRun();
                Console.WriteLine($"Stopping {this.Name}...");
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args) {
            new Server().Run(args);
            new Client().Run(args);
        }
    }
}

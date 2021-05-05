using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace AttributeExample {
	// ReSharper disable once UnusedType.Global
	public class Client {
		[Command("Client")]
		public void Run(string[] args) {
			var client = new TcpClient(new IPEndPoint(IPAddress.Any, 4445));
			client.Connect(IPAddress.Loopback, 4444);
			var stream = client.GetStream();
			var response = new StreamReader(stream).ReadToEnd();
			Console.WriteLine(response);
		}
	}
}
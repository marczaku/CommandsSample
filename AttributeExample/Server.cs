using System.IO;
using System.Net;
using System.Net.Sockets;

namespace AttributeExample {
	// ReSharper disable once UnusedType.Global
	public class Server {
		[Command("Server")]
		public void Run(string[] args) {
			var listener = new TcpListener(IPAddress.Any, 4444);
			listener.Start();
			var client = listener.AcceptTcpClient();
			var stream = client.GetStream();
			using var writer = new StreamWriter(stream);
			writer.Write("Hello World!");
		}
		
		[Command("Server2")]
		public void OtherRun(string[] args) {
			var listener = new TcpListener(IPAddress.Any, 4444);
			listener.Start();
			var client = listener.AcceptTcpClient();
			var stream = client.GetStream();
			using var writer = new StreamWriter(stream);
			writer.Write("Server 2 Ran");
		}
	}
}
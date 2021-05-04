using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CommandsSample {
	public class Server : ICommand {
		public void Run(string[] args) {
			var listener = new TcpListener(IPAddress.Any, 4444);
			listener.Start();
			var client = listener.AcceptTcpClient();
			var stream = client.GetStream();
			using var writer = new StreamWriter(stream);
			writer.Write("Hello World!");
		}
	}
}
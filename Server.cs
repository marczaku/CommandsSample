using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CommandsSample {
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
}
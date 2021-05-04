using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CommandsSample {
	public class HelloWorld : Command {
		protected override string Name => "hello-world";
		protected override void DoRun() {
			Console.WriteLine("HelloWorld!");
		}
	}
}
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CommandsSample {
	public class HelloWorld : ICommand {
		public void Run(string[] args) {
			Console.WriteLine("HelloWorld!");
		}
	}
}
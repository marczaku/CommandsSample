using System;

namespace AttributeExample {
	// ReSharper disable once UnusedType.Global
	public class HelloWorld{
		[Command("HelloWorld")]
		public void Run(string[] args) {
			Console.WriteLine("HelloWorld!");
		}
	}
}
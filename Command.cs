using System;

namespace CommandsSample {
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
}
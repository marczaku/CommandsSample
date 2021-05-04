using System;
using System.Reflection;

namespace CommandsSample
{
    class Program
    {
        static void Main(string[] args) {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes()) {
                // Skip types that do not match the name
                if (type.Name != args[0])
                    continue;
                // Skip types that do not inherit from Command
                if (!type.IsAssignableTo(typeof(ICommand)))
                    continue;
                // Skip types that are abstract (and can not be instantiated)
                if (type.IsAbstract)
                    continue;
                // Get the default constructor
                var constructor = type.GetConstructor(new Type[0]);
                // Use it
                var instance = constructor.Invoke(new object[0]);
                // Cast the result to the common base type
                var command = instance as ICommand;
                // And run the command
                Console.WriteLine($"Starting {type.Name}...");
                command.Run(args);
                Console.WriteLine($"Stopping {type.Name}...");
            }
        }
    }
}

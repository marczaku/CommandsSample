using System;
using System.Reflection;

namespace CommandsSample
{
    class Program
    {
        static void Main(string[] args) {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes()) {
                if (!type.IsAssignableTo(typeof(Command))) {
                    Console.WriteLine($"{type.Name} does not inherit from Command.");
                    continue;
                }

                if (type.IsAbstract) {
                    Console.WriteLine($"{type.Name} is Abstract.");
                    continue;
                }
                Console.WriteLine($"Found Command: {type.Name}");
                var constructor = type.GetConstructor(new Type[0]);
                var instance = constructor.Invoke(new object[0]);
                var command = instance as Command;
                command.Run(args);
            }
        }
    }
}

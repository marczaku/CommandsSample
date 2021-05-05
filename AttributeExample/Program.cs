using System;
using System.Linq;
using System.Reflection;

namespace AttributeExample
{
    class Program
    {
        static void Main(string[] args) {
            var assembly = Assembly.GetExecutingAssembly();
            
            foreach (var type in assembly.GetTypes()) {
                // Skip types that do not have any method with the CommandAttribute
                var validMethods = type.GetMethods()
                    .Where(method => method.GetCustomAttributes(typeof(CommandAttribute)).Any())
                    .ToArray();
                if (!validMethods.Any())
                    continue;
                // Skip types that are abstract (and can not be instantiated)
                if (type.IsAbstract)
                    continue;
                // Get The Method Which Matches Our First Argument
                var methodToCall= validMethods.FirstOrDefault(method => args[0].Equals(method.GetCustomAttribute<CommandAttribute>()?.CommandName, StringComparison.OrdinalIgnoreCase));
                // If it's null return
                if (methodToCall == null)
                    continue;
                var commandName = methodToCall.GetCustomAttribute<CommandAttribute>()?.CommandName;
                // Get the default constructor
                var constructor = type.GetConstructor(new Type[0]);
                // Use it
                var instance = constructor.Invoke(new object[0]);
                // And run the command using reflection
                Console.WriteLine($"Starting {commandName}...");
                methodToCall.Invoke(instance, new object[]{args});
                Console.WriteLine($"Stopping {commandName}...");
            }
        }
    }
}

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
                if (type.IsAbstract || type.IsInterface)
                    continue;
                // Get The Method Which Matches Our First Argument
                var methodToCall= validMethods.FirstOrDefault(method => args[0].Equals(method.GetCustomAttribute<CommandAttribute>()?.CommandName, StringComparison.OrdinalIgnoreCase));
                // If it's null return
                if (methodToCall == null)
                    continue;
                var commandName = methodToCall.GetCustomAttribute<CommandAttribute>()?.CommandName;
                // Get the default constructor
                var constructor = type.GetConstructor(new Type[0]);
                if (constructor == null)
                {
                    Console.WriteLine($"{type} Doesn't Have A Parameterless Constructor");
                    return;
                }
                // Use it
                var instance = constructor.Invoke(new object[0]);
                // And run the command using reflection
                Console.WriteLine($"Starting {commandName}...");
                switch (methodToCall.GetParameters().Length)
                {
                    case 1 when methodToCall.GetParameters()[0].ParameterType == typeof(string[]):
                        methodToCall.Invoke(instance, new object[]{args});
                        break;
                    case 0:
                        methodToCall.Invoke(instance, null);
                        break;
                    default:
                        Console.WriteLine($"Method Has Invalid Parameter {methodToCall} supported parameters are {typeof(string[])} or no parameters");
                        break;
                }
                Console.WriteLine($"Stopping {commandName}...");
                return;
            }
            Console.WriteLine($"No Command With The Name {args[0]} Was Found");
        }
    }
}

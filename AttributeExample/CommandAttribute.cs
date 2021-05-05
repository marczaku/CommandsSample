using System;

namespace AttributeExample
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        public readonly string CommandName;
        public CommandAttribute(string commandName)
        {
            this.CommandName = commandName;
        }
    }
}
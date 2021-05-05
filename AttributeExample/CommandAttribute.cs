using System;

namespace AttributeExample
{
    /// <summary>
    /// Should Only Be Used On Methods With A Signature Void (string[]) Or Void No Parameters.
    /// The Object Needs A Parameterless Constructor
    /// And Therefore Also Not Be Static.
    /// Name Should Be Unique
    /// </summary>
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
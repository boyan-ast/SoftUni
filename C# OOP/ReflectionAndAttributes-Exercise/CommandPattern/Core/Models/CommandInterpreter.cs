using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string commandPostfix = "Command";

        public string Read(string args)
        {
            string[] commandArgs = args.Split();

            string action = commandArgs[0];

            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                       .Any(i => i.Name == nameof(ICommand)))
                .FirstOrDefault(c => c.Name == (action + commandPostfix));

            string[] clearArgs = commandArgs.Skip(1).ToArray();

            ICommand command = (ICommand)Activator.CreateInstance(commandType);

            string result = command.Execute(clearArgs);

            return result;
        }
    }
}

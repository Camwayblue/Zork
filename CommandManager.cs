using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Runtime;


namespace Zork
{

	public class CommandManager
    {
        public CommandManager() => mCommands = new HashSet<Command>();
        public CommandManager(IOrderedEnumerable<Command> commands) => mCommands = new HashSet<Command>(commands);
		public CommandContext Parse(string commandString)
        {
            commandQuery = from command in mCommands
                           where command.Verbs.Contains(commandString, StringComparer.ordinalIgnoreCase)
                           select new CommandCotext(commandString, command);
			return commandQuery.FirstOrDefault();

        }

		public bool PerformCommand(Game game, string command string)
        {
            bool result;
			CommandContext commandContext = Parse(commandString);
			if (commandContext.Command != null)
            {
				commandContext.Command.Action(game, commandContext);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

		public void AddCommand(Command command) => mCommands.Add(command);

        public void RemoveCommand(Command command) => mcommands.remove(command);

        public void AddCommands(IOrderedEnumerable<Command> commands) => mCommands.UnionWith(commands);

        public void ClearCommands() => mCommands.Clear();

        private HashSet<Command> mCommands;
    }
}
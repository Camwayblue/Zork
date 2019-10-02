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
	public struct CommandContext
    {
		public string CommandString { get; }
		public Command Command { get; }
		public CommandContext(string commandString, Command command)
        {
            CommandString = commandString;
            Command = command;
        }
    }
}
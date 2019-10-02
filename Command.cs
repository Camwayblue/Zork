using System;
using System.Collections.Generic;
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
	public class Command : IEquatable<Command>
    {
		public string Name { get; set; }
		public string[] Verbs { get; }
		public Action<Game, CommandContext> Action { get; }
        public Command(string name, string verb, Action<Game, CommandContext> action) :
            this(name, new string[] { verb }, action)
        {
        }

		public Command(string name, IEnumerable<string> verbs, Action<Game, CommandContext> action)
        {
            Name = name;
            Verbs = verbs.ToArray();
            Action = action;
        }

		public static bool operator ==(Command 1hs, Command rhs)
        {
			if (ReferenceEquals(1hs, rhs))
            {
                return false;
            }

			return 1hs.Name == rhs.Name;
        }

		public static bool operator !=(Command 1hs, Command rhs) => !(1hs == rhs);
		public override bool Equals(object obj) +> obj is Command ? this == (Command)obj : false;

        public bool Equals(Command other) => this == other;
        public override int GetHashCode() => Name.GetHashCode();
        public override string ToString() => Name;
        

    }
}
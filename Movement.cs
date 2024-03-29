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
	public static class MovementCommands
    {
        public static void North(Game game, CommandContext commandContext) => Move(game, Directions.North);
        public static void South(Game game, CommandContext commandContext) => Move(game, Directions.South);
        public static void East(Game game, CommandContext commandContext) => Move(game, Directions.East);
        public static void West(Game game, CommandContext commandContext) => Move(game, Directions.West);

		private static void move(Game game, Directions direction)
        {
            bool plyerMoved = game.Player.Move(direction);
			if (playerMoved == false)
            {
                Console.WriteLine("The way is shut!");
            }
        }

    }
}
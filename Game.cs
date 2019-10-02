using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Zork
{
    public class Game
    {
        public World World { get; private set; }
        [JsonIgnore]
        public Player Player { get; private set; }

        [JsonIgnore]
        private bool IsRunning { get; set; }

        public Game(World world, Player player)
        {
            World = world;
            Player = player;
        }

        public Game()
        {
            Command[] commands =
            {
                new Command("LOOK", new string[] {"LOOK", "L" },
                (game, commandContext) => Console.WriteLine(game.Player.Location.Description)),

                new Command("QUIT", new string[] {"QUIT", "Q" },
                (game, commandContext) => game.IsRunning = false),

                new Command("NORTH", new string[] {"NORTH", "N" }, MovementCommands.North),
                new Command("SOUTH", new string[] {"SOUTH", "S" }, MovementCommands.North),
                new Command("EAST", new string[] {"EAST", "E" }, MovementCommands.North),
                new Command("WEST", new string[] {"WEST", "W" }, MovementCommands.North),
            };

            CommandManager = new CommandManager(commands);
        }

        public void Run()
        {
            #region old run
            /* IsRunning = true;
             Room previousRoom = null;
             while (IsRunning)
             {
                 Console.WriteLine(Player.Location);
                 if (previousRoom != Player.Location)
                 {
                     Console.WriteLine(Player.Location.Description);
                     previousRoom = Player.Location;
                 }
                 //}
                 Console.Write("\n> ");
                 Commands command = ToCommand(Console.ReadLine().Trim());

                 switch (command)
                 {
                     case Commands.QUIT:
                         IsRunning = false;
                         break;

                     case Commands.LOOK:
                         Console.WriteLine(Player.Location.Description);
                         break;

                     case Commands.NORTH:
                     case Commands.SOUTH:
                     case Commands.EAST:
                     case Commands.WEST:
                         Directions direction = Enum.Parse<Directions>(command.ToString(), true);
                         if (Player.Move(direction) == false)
                         {
                             Console.WriteLine("The way is shut!");
                         }
                         break;

                     default:
                         Console.WriteLine("Unknown command.");
                         break;
                 }
             }*/
            #endregion 

            IsRunning = true;
            Room previousRoom = null;
            while (IsRunning)
            {
                Console.WriteLine(Player.Location);
                if(previousRoom != Player.Location)
                {
                    CommandManager.PerformCommand(this, "LOOK");
                    previousRoom = Player.Location;
                }

                Console.Write("\n> ");
                if (CommandManager.PerformComman(this, Console.ReadLine().Trim()))
                {
                    Player.Moves++;
                }
                else
                {
                    Console.WriteLine("That's not a verb i reconize.");
                }
            }
        }
        public static Game Load(string filename)
        {
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(filename));
            game.Player = game.World.SpawnPlayer();

            return game;
        }
       // private static Commands ToCommand(string commandString) => Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        /*{
            Commands result;
            return Enum.TryParse<Commands>(commandstring, true, out result) ? result : Commands.UNKNOWN;
        }*/

  
    }
}

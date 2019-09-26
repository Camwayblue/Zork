using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Zork
{
    class Program
    {

        private static bool Move(Commands command)
        {
            Assert.IsTrue(IsDirection(command), "Invalid Directions.");
            bool isValidMove = true;
            switch (command)
            {
                case Commands.EAST:
                    if (Location.Column > 0)
                    {
                        Location.Column--;
                    }
                    else
                        isValidMove = false;
                    break;
                case Commands.WEST:
                    if (Location.Column < Rooms.GetLength(1) - 1)
                    {
                        Location.Column++;
                    }
                    else
                        isValidMove = false;
                    break;
                case Commands.NORTH:
                    if (Location.Row > 0)
                    {
                        Location.Row--;
                    }
                    else
                        isValidMove = false;
                    break;
                case Commands.SOUTH:
                    if (Location.Row < Rooms.GetLength(0) - 1)
                    {
                        Location.Row++;
                    }
                    else
                        isValidMove = false;
                    break;
                default:
                    isValidMove = false;
                    break;

            }
            return isValidMove;
        }
        private static Commands Tocommand(string commandstring)
        {
            Commands result;
            return Enum.TryParse(commandstring, true, out result) ? result : Commands.UNKNOWN;
        }

        private static readonly string[,] Rooms = {
                                                      {"Rocky Trail","South of House","Canyon View"},
                                                      {"Forest","West of House","Behind House"},
                                                      {"Dense Woods","North of House","Clearing"},
                                                  };
        private static class Location
        {
            public static int Row = 1;
            public static int Column = 1;
        }

        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };

        private static bool IsDirection(Commands command)
        {
            return Directions.Contains(command);
        }

        private static string CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            Console.WriteLine("Player Spawned in Room : {0}", Rooms[Location.Row, Location.Column]);
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                string outputstring = "";
                Console.WriteLine("Current Room : {0}", CurrentRoom);
                Console.Write(">");
                command = Tocommand(Console.ReadLine().Trim());
                switch (command)
                {
                    case Commands.LOOK:
                        Console.WriteLine("A Rubber Mat saying 'Welcome to Zork!' liest by the door.");
                        break;
                    case Commands.EAST:
                    case Commands.WEST:
                    case Commands.NORTH:
                    case Commands.SOUTH:
                        if (!Move(command))
                        {
                            outputstring = "The Way is Shut";
                        }
                        break;
                    case Commands.QUIT:
                        Console.Write("Thank you for Playing!");
                        break;
                    default:
                        outputstring = "Unknown Command";
                        break;
                }
                Console.WriteLine(outputstring);
            }
            Console.ReadLine();
        }
    }
}

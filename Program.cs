using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Program
    {
        private static Commands Tocommand(string commandstring)
        {
            Commands result;
            return Enum.TryParse(commandstring, true, out result) ? result : Commands.UNKNOWN;
        }
      
        private static Commands move(string commandstring)
        {
            Commands result;
            return Enum.TryParse(commandstring, true, out result) ? result == Commands.EAST ? result : result == Commands.WEST ? result : Commands.UNKNOWN : Commands.UNKNOWN;
        }

        //private static string[] Rooms =  {"Forest","West of House","Behind of House", "Clearing", "Canyon View"};
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

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            Console.WriteLine("Player Spawned in Room : {0}", Rooms[Location.Row, Location.Column]);
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine("Current Room : {0}", Rooms[Location.Row, Location.Column]);
                Console.Write(">");
                command = Tocommand(Console.ReadLine().Trim());
                string outputstring = "";
                switch (command)
                {
                    case Commands.EAST:
                        if (Location.Column > 0)
                        {
                            Location.Column--;
                            outputstring = "You Moved to " + command + ".";
                        }
                        else
                        {
                            outputstring = "The Way is shut";
                        }
                        break;
                    case Commands.WEST:
                        if (Location.Column < (Rooms.Length / 3) - 1)
                        {
                            Location.Column++;
                            outputstring = "You Moved to " + command + ".";
                        }
                        else
                        {
                            outputstring = "The Way is Shut";
                        }
                        break;
                    case Commands.NORTH:
                        if (Location.Row > 0)
                        {
                            Location.Row--;
                            outputstring = "You Moved to " + command + ".";
                        }
                        else
                        {
                            outputstring = "The Way is shut";
                        }
                        break;
                    case Commands.SOUTH:
                        if (Location.Row < (Rooms.Length / 3) - 1)
                        {
                            Location.Row++;
                            outputstring = "You Moved to " + command + ".";
                        }
                        else
                        {
                            outputstring = "The Way is Shut";
                        }
                        break;
                    case Commands.QUIT:
                        break;
                    default:
                        outputstring = "Unknown Command";
                        break;
                }
                Console.WriteLine(outputstring);
            }
            Console.Write("Thank you for Playing!");
            Console.ReadLine();

        }
    }
}

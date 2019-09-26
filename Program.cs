using System;

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

        private static string[] Rooms = { "Forest", "West of House", "Behind of House", "Clearing", "Canyon View" };
        static void Main(string[] args)
        {
            int CurrentRoom = 1;
            Console.WriteLine("Welcome to Zork!");
            Console.WriteLine("Player Spawned in Room : {0}", Rooms[CurrentRoom]);
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine("Current Room : {0}", Rooms[CurrentRoom]);
                Console.Write(">");
                command = move(Console.ReadLine().Trim());
                string outputstring;
                switch (command)
                {
                    case Commands.EAST:
                        if (CurrentRoom > 0)
                        {
                            CurrentRoom--;
                            outputstring = "You Moved to " + command + ".";
                        }
                        else
                        {
                            outputstring = "You cannot move any further East";
                        }
                        break;
                    case Commands.WEST:
                        if (CurrentRoom < Rooms.Length - 1)
                        {
                            CurrentRoom++;
                            outputstring = "You Moved to " + command + ".";
                        }
                        else
                        {
                            outputstring = "The Way is Shut";
                        }
                        break;
                    default:
                        outputstring = "Unknown Command";
                        break;
                }
                Console.WriteLine(outputstring);
            }
        }
    }
}

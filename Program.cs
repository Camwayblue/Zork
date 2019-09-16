using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;
                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door.");
                        break;
                    case Commands.NORTH:
                        Console.WriteLine("You moved North");
                        break;
                    case Commands.SOUTH:
                        Console.WriteLine("You moved SOUTH");
                        break;
                    case Commands.EAST:
                        Console.WriteLine("You moved EAST");
                        break;
                    case Commands.WEST:
                        Console.WriteLine("You moved WEST");
                        break;
                    case Commands.UNKNOWN:
                        Console.WriteLine("Unkown command");
                        break;
                }

                Console.WriteLine(outputString);
            }
       

        }
        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
    }
}

using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            Console.ReadKey();

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
                 
                    case Commands.SOUTH:

                    case Commands.EAST:

                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;

                    default:
                        Console.WriteLine("Unkown command");
                        break;
                }

             //   Console.WriteLine(outputString);
            }


        }
        private static Commands ToCommand(string commandString) => (Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN);

        

        
            private static readonly string[,] Rooms = { "Forest", "West of House", "Behind House", "Clearing", "Canyon View" };
           
        
    }
}

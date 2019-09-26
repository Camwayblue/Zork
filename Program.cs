using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Rooms = { "Forest", "West of House", "Behind House", "Clearing", "Canyon View" };
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
                        outputString = "Thank you for playing!";
                        break;
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door.";
                        break;
                    case Commands.NORTH:
                 
                    case Commands.SOUTH:

                    case Commands.EAST:

                    case Commands.WEST:
                        outputString = $"You moved {command}."
                        break;

                    default:
                        outputString = "Unkown command";
                        break;
                }

             //   Console.WriteLine(outputString);
            }


        }

        private static Commands ToCommand(string commandString) => (Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN);

           
        
    }
}

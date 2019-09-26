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

        #region Data Members

        public class Room
        {
            private string mName;
            private string mDescription;
            public string Name
            {
                get
                {
                    return mName;
                }
                set
                {
                    mName = value;
                }
            }
            public string Description
            {
                get
                {
                    return mDescription;
                }
                set
                {
                    mDescription = value;
                }
            }
            public Room(string name, String description = "")
            {
                Name = name;
                Description = description;
            }
        }

        private static readonly Room[,] Rooms = {
                                                      { new Room("Rocky Trail"),new Room("South of House"), new Room("Canyon View")},
                                                      {new Room("Forest"),new Room("West of House"),new Room("Behind House")},
                                                      {new Room("Dense Woods"),new Room("North of House"),new Room("Clearing")},
                                                  };

        private static void InitializationDescription()
        {
            Rooms[0, 0].Description = "You are on a Rock-stream Trail.";
            Rooms[0, 1].Description = "Your are facing the south side of the white house. There is no door here, and all the windows are barred.";
            Rooms[0, 2].Description = "You are at the top of the Great canyon on its south wall.";

            Rooms[1, 0].Description = "This is a forest, with trees in all direction around you.";
            Rooms[1, 1].Description = "This is an open field west of a white house, with a boarded front door.";
            Rooms[1, 2].Description = "You are behind the white house. In one corner of the house there is a small window which is slightly ajar.";

            Rooms[2, 0].Description = "This is a daily lit forest, with large trees all around. To the east, there apprears to be sunlight.";
            Rooms[2, 1].Description = "You are facing the north side of a white house. There is no door here, and all the windows are barred.";
            Rooms[2, 2].Description = "You are in a clearing, with a fores surrounding you on the west and south.";
        }
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


        private static Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }
        #endregion

        #region Functions
        private static bool IsDirection(Commands command)
        {
            return Directions.Contains(command);
        }

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
        #endregion

        #region Main Method

        static void Main(string[] args)
        {
            InitializationDescription();
            Console.WriteLine("Welcome to Zork!");
            Console.WriteLine("Player Spawned in Room : {0}", CurrentRoom.Name);
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                string outputstring = "";
                Console.WriteLine("Current Room : {0}", CurrentRoom.Name);
                Console.Write(">");
                command = Tocommand(Console.ReadLine().Trim());
                switch (command)
                {
                    case Commands.LOOK:
                        Console.WriteLine(CurrentRoom.Description);
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
        #endregion
    }
}

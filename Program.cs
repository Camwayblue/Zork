using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Zork
{
    class Program
    {
        static Program()
        {
            RoomMap = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
            {
                RoomMap[room.Name] = room;
            }
        }

        #region Data Members
        private static readonly Dictionary<string, Room> RoomMap;

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


        /* Without Linq below is with LINQ */
        private static void InitializationDescription(string roomFilename)
        {
            const string fieldDelimiter = "##";
            const int expectedFieldCount = 2;
            string[] lines = File.ReadAllLines(roomFilename);
            foreach (var line in lines)
            {
                string[] fields = line.Split(fieldDelimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (fields.Length != expectedFieldCount)
                {
                    throw new InvalidDataException("Invalid Record");
                }

                string name = fields[(int)Fields.Name];
                string description = fields[(int)Fields.Description];

                RoomMap[name].Description = description;
            }
        }

        //private static void InitializationDescription2(string roomFilename)
        //{
        //    const string fieldDelimiter = "##";
        //    const int expectedFieldCount = 2;
        //    var roomQuery = from line in File.ReadAllLines(roomFilename)
        //                    let fields = line.Split(fieldDelimiter.ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
        //                    where fields.Length == expectedFieldCount
        //                    select (Name: Fields[(int)Fields.Name],
        //                            Description: Fields[(int)Fields.Description])

        //    foreach (var (Name, Description) in roomQuery)
        //    {
        //        RoomMap[Name].Description = Description;
        //    }
        //}



        private static class Location
        {
            public static int Row = 1;
            public static int Column = 1;
        }

        private enum Fields
        {
            Name = 0,
            Description
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
        const string defaultRoomFileName = "Rooms.txt";
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

            InitializationDescription(defaultRoomFileName);
            Console.WriteLine("Welcome to Zork!");
            Room PreviewsRoom = null;
            Console.WriteLine("Player Spawned in Room : {0}", CurrentRoom.Name);
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                string outputstring = "";
                Console.WriteLine("Current Room : {0}", CurrentRoom.Name);
                if (PreviewsRoom != CurrentRoom)
                {
                    Console.WriteLine(CurrentRoom.Description);
                    PreviewsRoom = CurrentRoom;
                }
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

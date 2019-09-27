/*public class Game
        {
            public World World { get; private set; }
            [JsonIgnore]
            public Player Player { get; private set; }

            [JsonIgnore]
            private bool isRunning { get; set; }

            public Game(World world, Player player)
            {
                World = world;
                Player = player;
            }
            public void Run()
            {
                isRunning = true;
                Room previousRoom = null;
                while (isRunning)
                {
                    Console.WriteLine(Player.Location);
                    if (previousRoom != Player.Location)
                    {
                        Console.WriteLine(Player.Location.Description);
                        previousRoom = Player.Location;
                    }
                }
                Console.WriteLine("\n> ");
                Commands command = toCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.LOOK:
                    case Commands.NORTH;
                    case Commands.SOUTH;
                    case Commands.EAST;
                    case Commands.WEST;
                        Directions direction = Enum.Parse<Directions>(command.ToString(), true);
                        if (Player.Move(direction) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown Command.");
                        break;
                }
            }
            public static Game Load(string filename)
            {
                Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(filename));
                game.Player = game.Player.SpawnPlayer();

                return game;
            }
            private static Commands Tocommand(string commandstring)
            {
                Commands result;
                return Enum.TryParse<Commands>(commandstring, true, out result) ? result : Commands.UNKNOWN;
            }
        } */
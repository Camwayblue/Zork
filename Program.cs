using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Runtime;


namespace Zork
{

    class Program
    {


        #region Data Members

        /*private static class Location
        {
            public static int Row = 1;
            public static int Column = 1;
        }

        private enum Fields
        {
            Name = 0,
            Description
        }
        */
        #endregion

        #region Main Method

        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename);

            Game game = Game.Load(gameFilename);
            Console.WriteLine("Welcome to Zork!");
            game.Run();
            Console.WriteLine("Thank you for playing!");


        } 
        private enum CommandLineArguments
        {
            GameFilename = 0
        }
        #endregion
    }

}
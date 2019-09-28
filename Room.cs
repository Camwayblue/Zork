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
    public class Room : IEquatable<Room>
    {
        [JsonProperty(Order = 1)]
        public string Name { get; private set; }

        [JsonProperty(Order = 2)]
        public string Description { get; private set; }

        [JsonProperty(PropertyName = "Neighbors", Order = 3)]
        private Dictionary<Directions, string> NeighborNames { get; set; }

        [JsonIgnore]
        public IReadOnlyDictionary<Directions, Room> Neighbors { get; private set; }

        public static bool operator ==(Room lhs, Room rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }
            if (lhs is null || rhs is null)
            {
                return false;
            }
            return lhs.Name == rhs.Name;
        }
        public static bool operator !=(Room lhs, Room rhs) => !(lhs == rhs);
        /*{
            return !(lhs == rhs);
        }*/
        public override bool Equals(object obj) => obj is Room room ? this == room : false;
        public bool Equals(Room other) => this == other;
        /*{
            return this == other;
        }*/
        public override string ToString() => Name;
        /*{
            return Name;
        }*/
        public override int GetHashCode() => Name.GetHashCode();

        /*public IReadOnlyDictionary<Directions, Room> UpdateNeighbors(World world)
        {
            return Neighbors = (from entry in NeighborNames
                                let room = world.RoomsByName.GetValueOrDefault(entry.Value)
                                where room != null
                                select (Direction: entry.Key, Rooms: room))
            .ToDictionary(pair => pair.Direction, pair => pair.Rooms);
        }*/
        public void UpdateNeighbors(World world) => Neighbors = (from entry in NeighborNames
                                                                 let room = world.RoomsByName.GetValueOrDefault(entry.Value)
                                                                 where room != null
                                                                 select (Direction: entry.Key, Room: room))
                                                                 .ToDictionary(pair => pair.Direction, pair => pair.Room);

    }
}
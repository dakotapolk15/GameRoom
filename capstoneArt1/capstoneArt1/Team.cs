

using System;
using System.Collections.Generic;
using System.Linq;

namespace GamingRoom 
{
    // teams with multiple players
    public class Team : Entity 
    {
        public long Id { get; set; }
        public string Name { get; set; }

        
        // store player associated wiht team
        public List<Player> Players = new List<Player>();

        // initialize team with id and name 
        public Team(long id, string name) : base(id, name) 
        {
            Id = id;
            Name = name;
            Players = new List<Player>();
        }

        // adds new player to team if not exits
        public Player AddPlayer(string name) 
        {
            // player exists
            Player player = Players.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (player == null) 
            {
                player = new Player(GetNextPlayerId(), name);
                Players.Add(player);
            }
            return player;
        }

        // add player to team
        public void AddPlayer(Player player) 
        {
            Players.Add(player);
        }

        // gets next player id based on current player count
        private long GetNextPlayerId() 
        {
            return Players.Count + 1;
        }

        // returns string of team
        public override string ToString()
        {
            return $"Team [id={base.Id}, name={base.Name}]";
        }
    }
}

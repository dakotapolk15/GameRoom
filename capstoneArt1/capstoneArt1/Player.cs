
using System;

namespace GamingRoom 
{
    // inherits form entity unique id and name
    public class Player : Entity 
    {
        public Player(long id, string name) : base(id, name) 
        {
            
        }

        public Player(long id, string name, Team team) : base(id, name) 
        {
            this.Team = team;
        }

        // get or set teams to players belongs to
        public Team Team { get; set; }

        // return string of the player
        public override string ToString()
        {
            return $"Player [id={base.Id}, name={base.Name}]";
        }
    }
}

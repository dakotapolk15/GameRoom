
using GamingRoom;
using System;
using System.Collections.Generic;

namespace GamingRoom
{
    // inherts the entity class that gives id and names 
    public class Game : Entity
    {
        private List<Team> teams = new List<Team>();

        // gives game initializtion wiht id and name
        public Game(long id, string name) : base(id, name)
        {

        }

        // list of teams that are with the game
        public Game(long id, string name, List<Team> teams) : base(id, name)
        {
            this.teams = teams;
        }

        // add team to the game 
        public Team AddTeam(long id, string name)
        {
            Team team = null;

            // see if team already exists 
            foreach (var teamInstance in teams)
            {
                if (teamInstance.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    team = teamInstance;
                    break;
                }
            }
            // there no team create new team add to list 
            if (team == null)
            {
                 team = new Team(id,name);
                
                teams.Add(team);
            }
            return team;
        }

        // list of team within the game
        public List<Team> GetTeams() 
        {
            return teams;
        }

        // gets teams by unique id
        public Team GetTeamById(long id) 
        {
            return teams.FirstOrDefault(team => team.Id == id);
        }

        // returns the game as string
        public override string ToString()
        {
            return $"Game [id={base.Id}, name={base.Name}]";
        }
    }
}
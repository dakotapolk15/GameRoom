

using System;
using System.Collections.Generic;

namespace GamingRoom
{
    public class GameService
    { 
        private static List<Game> games = new List<Game>();
        // gives the next ids 
        private static long nextGameId = 1;
        private static long nextTeamId = 1;
        private static long nextPlayerId = 1;

        private static GameService instance = new GameService();

        private GameService() 
        {
        
        }

        public static GameService GetInstance() 
        {
          
            if (instance == null)
            {
                instance = new GameService();
                Console.WriteLine("New Game Service created.");
            }
            else
            {
                Console.WriteLine("Game Service already instantiated.");
            }
            return instance;
        }
        // add new game if not exists 
        public Game AddGame(string name) 
        {
            
            // checks if game name exists
            foreach (var gameInstance in games)
            {
                if (gameInstance.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                { 
                    return gameInstance;
                }
            }
            // give new game unique id 
            Game game = new Game(nextGameId++, name);

            // default team
            game.AddTeam(GameService.GetInstance().GetNextTeamId(), "Default Team");
            
            // add new game to list
            games.Add(game);

            return game;
        }

        // gets game by index
        public Game GetGame(int index) 
        {
            if(index >= 0 && index < games.Count) 
            {
                return games[index];
            }
            else 
            {
                return null;
            }
        }

        // get game unique id
        public Game GetGame(long id) 
        { 
            foreach (var gameInstance in games) 
            {
                if (gameInstance.Id == id) 
                {
                    return gameInstance;
                }
            }
            return null;
        }

        // gets game by its name 
        public Game GetGame(string name) 
        {
            foreach (var gameInstance in games) 
            {
                if (gameInstance.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) 
                {
                    return gameInstance;
                }
            }
            return null;
        }

        // gives total number of games
        public int GetGameCount() 
        {
            return games.Count;
        }

        // returns unique player id 
        public long GetNextPlayerId() 
        {
            return nextPlayerId++;
        }

        // returns unique team id
        public long GetNextTeamId() 
        {
            return nextTeamId++;
        }
    }
}
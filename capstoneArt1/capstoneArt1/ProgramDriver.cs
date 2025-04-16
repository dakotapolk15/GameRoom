// Dakota Polk 3.19.25

using System;
using System.ComponentModel.Design;
using GamingRoom;

namespace GamingRoom
{
    class ProgramDrivers
    {
        static void Main(string[] args)
        {
            var gameService = GameService.GetInstance();
            bool running = true;

            // Loop with error handling
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome");
                Console.WriteLine("1. Add a new game");
                Console.WriteLine("2. List all games");
                Console.WriteLine("3. Add a team to a game");
                Console.WriteLine("4. Add a player to a team");
                Console.WriteLine("5. View game details");
                Console.WriteLine("6. Exit");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewGame(gameService);
                        break;
                    case "2":
                        ListAllGames(gameService);
                        break;
                    case "3":
                        AddTeamToGame(gameService);
                        break;
                    case "4":
                        AddPlayerToTeam(gameService);
                        break;
                    case "5":
                        ViewGameDetails(gameService);
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Exiting... Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void AddNewGame(GameService gameService)
        {
            Console.Write("Enter the name of the new game: ");
            string gameName = Console.ReadLine();

            // Error check
            if (string.IsNullOrWhiteSpace(gameName))
            {
                Console.WriteLine("Game name cannot be empty.");
                return;
            }

            var game = gameService.AddGame(gameName);
            Console.WriteLine($"Game '{game.Name}' added with ID {game.Id}.");
        }

        private static void ListAllGames(GameService gameService)
        {
            int gameCount = gameService.GetGameCount();

            if (gameCount > 0)
            {
                Console.WriteLine("List of all games:");
                for (int i = 0; i < gameCount; i++)
                {
                    var game = gameService.GetGame(i);
                    Console.WriteLine($"ID: {game.Id}, Name: {game.Name}");
                }
            }
            else
            {
                Console.WriteLine("No games available.");
            }
        }

        private static void AddTeamToGame(GameService gameService)
        {
            Console.Write("Enter the Game ID to add a team to: ");
            // error check
            if (!long.TryParse(Console.ReadLine(), out long gameId))
            {
                Console.WriteLine("Invalid input! Please enter a valid numeric Game ID.");
                return;
            }

            var game = gameService.GetGame(gameId);
            if (game == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }

            Console.Write("Enter the name of the new team: ");
            string teamName = Console.ReadLine();
            // error check
            if (string.IsNullOrWhiteSpace(teamName))
            {
                Console.WriteLine("Team name cannot be empty.");
                return;
            }

            long teamId = gameService.GetNextTeamId();
            game.AddTeam(teamId, teamName);
            Console.WriteLine($"Team '{teamName}' added to Game '{game.Name}'.");
        }

        private static void AddPlayerToTeam(GameService gameService)
        {
            Console.Write("Enter the Game ID to add a player to: ");
            // error check
            if (!long.TryParse(Console.ReadLine(), out long gameId))
            {
                Console.WriteLine("Invalid input! Please enter a valid numeric Game ID.");
                return;
            }

            var game = gameService.GetGame(gameId);
            if (game == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }

            Console.Write("Enter the Team ID to add a player to: ");
            // error check
            if (!long.TryParse(Console.ReadLine(), out long teamId))
            {
                Console.WriteLine("Invalid input! Please enter a valid numeric Team ID.");
                return;
            }

            var team = game.GetTeamById(teamId);
            if (team == null)
            {
                Console.WriteLine("Team not found.");
                return;
            }

            Console.Write("Enter player name: ");
            string playerName = Console.ReadLine();
            // error check
            if (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Player name cannot be empty.");
                return;
            }

            var player = new Player(gameService.GetNextPlayerId(), playerName);
            team.AddPlayer(player);
            Console.WriteLine($"Player '{player.Name}' added to Team '{team.Name}'.");
        }

        private static void ViewGameDetails(GameService gameService)
        {
            Console.Write("Enter the Game ID to view details: ");
            // error check
            if (!long.TryParse(Console.ReadLine(), out long gameId))
            {
                Console.WriteLine("Invalid input! Please enter a valid numeric Game ID.");
                return;
            }

            var game = gameService.GetGame(gameId);
            if (game == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }

            Console.WriteLine($"Game ID: {game.Id}");
            Console.WriteLine($"Game Name: {game.Name}");
            Console.WriteLine("Teams:");
            // put players in list under team there with 
            foreach (var team in game.GetTeams())
            {
                Console.WriteLine($"- {team.Name} (ID: {team.Id})");

                if (team.Players.Count > 0)
                {
                    Console.WriteLine("  Players:");
                    foreach (var player in team.Players)
                    {
                        Console.WriteLine($"  - {player.Name} (ID: {player.Id})");
                    }
                }
                else
                {
                    Console.WriteLine("  No players in this team yet.");
                }
            }
        }
    }
}




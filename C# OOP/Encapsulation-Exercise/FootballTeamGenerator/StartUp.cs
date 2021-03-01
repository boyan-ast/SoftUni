using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(';');

                string action = commandArgs[0];
                string teamName = commandArgs[1];
                Team selectedTeam = teams.FirstOrDefault(t => t.Name == teamName);

                if (action != "Team" && selectedTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist.");
                    continue;
                }

                if (action == "Team")
                {
                    try
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == "Add")
                {
                    string playerName = commandArgs[2];

                    int endurance = int.Parse(commandArgs[3]);
                    int sprint = int.Parse(commandArgs[4]);
                    int dribble = int.Parse(commandArgs[5]);
                    int passing = int.Parse(commandArgs[6]);
                    int shooting = int.Parse(commandArgs[7]);
                    try
                    {
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        selectedTeam.AddPlayer(player);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                else if (action == "Remove")
                {
                    string playerName = commandArgs[2];

                    if (!selectedTeam.RemovePlayer(playerName))
                    {
                        Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                    }

                }
                else if (action == "Rating")
                {
                    Console.WriteLine($"{teamName} - {selectedTeam.Rating}");
                }
            }
        }
    }
}

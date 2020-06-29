using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            List<string> allMembers = new List<string>();

            List<Team> AllTeams = new List<Team>();
            AddTeams(numberOfTeams, AllTeams);

            foreach (Team team in AllTeams)
            {
                allMembers.Add(team.Creator);
            }

            AddMembers(allMembers, AllTeams);

            PrintTheTeams(AllTeams);
        }

        private static void PrintTheTeams(List<Team> AllTeams)
        {
            List<Team> filteredTeams = AllTeams
                            .Where(x => x.Members.Count > 0)
                            .OrderByDescending(x => x.Members.Count)
                            .ThenBy(x => x.Name)
                            .ToList();

            List<Team> teamsToDisband = AllTeams
                .Where(x => x.Members.Count == 0)
                .OrderBy(y => y.Name)
                .ToList();


            foreach (Team team in filteredTeams)
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                team.Members.Sort();

                foreach (string member in team.Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team team in teamsToDisband)
            {
                Console.WriteLine(team.Name);
            }
        }

        private static void AddMembers(List<string> allMembers, List<Team> AllTeams)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] playerInfo = command.Split("->");
                string playerName = playerInfo[0];
                string teamName = playerInfo[1];

                bool teamExists = AllTeams.Any(x => x.Name == teamName);

                if (!teamExists)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (allMembers.Contains(playerName))
                {
                    Console.WriteLine($"Member {playerName} cannot join team {teamName}!");
                    continue;
                }

                foreach (Team team in AllTeams)
                {
                    if (team.Name == teamName)
                    {
                        team.Members.Add(playerName);
                        allMembers.Add(playerName);
                        break;
                    }
                }
            }
        }

        private static void AddTeams(int teams, List<Team> AllTeams)
        {
            for (int i = 0; i < teams; i++)
            {
                string[] newTeamInputInfo = Console.ReadLine().Split("-");
                string creator = newTeamInputInfo[0];
                string teamName = newTeamInputInfo[1];

                bool creatorExists = AllTeams.Select(x => x.Creator).Contains(creator);
                bool teamExists = AllTeams.Select(x => x.Name).Contains(teamName);

                if (!creatorExists && !teamExists)
                {
                    Team newTeam = new Team();
                    newTeam.Creator = creator;
                    newTeam.Name = teamName;
                    AllTeams.Add(newTeam);

                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
                else if (teamExists)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (creatorExists)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
            }
        }

        class Team
        {
            public string Creator { get; set; }
            public string Name { get; set; }
            public List<string> Members { get; set; }
            

            public Team()
            {
                Members = new List<string>();
            }
           
        }
    }
}

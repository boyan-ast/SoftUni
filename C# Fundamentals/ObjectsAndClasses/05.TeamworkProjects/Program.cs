using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> allTeams = new List<Team>(n);
            List<string> allPlayers = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] teamData = Console.ReadLine().Split("-");
                string creator = teamData[0];
                string name = teamData[1];

                if (allTeams.FindIndex(t => t.Name == name) != -1)
                {
                    Console.WriteLine($"Team {name} was already created!");
                }
                else if (allTeams.FindIndex(t => t.Creator == creator) != -1)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team newTeam = new Team();
                    newTeam.Name = name;
                    newTeam.Creator = creator;

                    Console.WriteLine($"Team {name} has been created by {creator}!");

                    allTeams.Add(newTeam);
                    allPlayers.Add(creator);
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] memeberData = command.Split("->");
                string memberName = memeberData[0];
                string teamToJoin = memeberData[1];

                if (allTeams.FindIndex(t => t.Name == teamToJoin) == -1)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (allPlayers.Contains(memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!");
                }
                else
                {
                    Team existingTeam = allTeams.FirstOrDefault(t => t.Name == teamToJoin);
                    existingTeam.Members.Add(memberName);
                    allPlayers.Add(memberName);
                }
            }

            foreach (Team team in allTeams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name))
            {
                Console.WriteLine(team);
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team team in allTeams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name))
            {
                Console.WriteLine(team);
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

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();


            if (Members.Count == 0)
            {
                text.Append($"{Name}");
                return text.ToString().Trim();
            }
            else
            {
                text.AppendLine($"{Name}");
                text.AppendLine($"- {Creator}");

                Members.Sort();

                foreach (string member in Members)
                {
                    text.AppendLine($"-- {member}");
                }

                return text.ToString().Trim();
            }

        }
    }
}

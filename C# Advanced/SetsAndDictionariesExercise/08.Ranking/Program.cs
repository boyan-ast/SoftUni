using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string command = string.Empty;

            while (((command = Console.ReadLine()) != "end of contests"))
            {
                string[] contestInfo = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contestName = contestInfo[0];
                string password = contestInfo[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests[contestName] = password;
                }
            }

            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] userInfo = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = userInfo[0];
                string password = userInfo[1];
                string username = userInfo[2];
                int points = int.Parse(userInfo[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                    }

                    if ((users[username].ContainsKey(contest) && users[username][contest] < points)
                        || !users[username].ContainsKey(contest))
                    {
                        users[username][contest] = points;
                    }
                }
            }

            var orderedUsers = users
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Best candidate is {orderedUsers.First().Key} with total {orderedUsers.First().Value.Values.Sum()} points.");

            Console.WriteLine("Ranking:");

            foreach (var student in users.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key}");

                foreach (var contest in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}

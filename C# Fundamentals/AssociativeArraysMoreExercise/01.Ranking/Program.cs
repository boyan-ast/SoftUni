using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end of contests")
            {
                string contest = command.Split(':')[0];
                string password = command.Split(':')[1];

                contests.Add(contest, password);
            }

            var users = new SortedDictionary<string, Dictionary<string, int>>();

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] userInfo = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = userInfo[0];
                string password = userInfo[1];

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    string username = userInfo[2];
                    int points = int.Parse(userInfo[3]);

                    if (users.ContainsKey(username))
                    {
                        if (users[username].ContainsKey(contest))
                        {
                            if (users[username][contest] < points)
                            {
                                users[username][contest] = points;
                            }
                        }
                        else
                        {
                            users[username].Add(contest, points);
                        }
                    }
                    else
                    {
                        users[username] = new Dictionary<string, int>();
                        users[username].Add(contest, points);
                    }
                }
            }

            string bestCandidateName = users
                .OrderByDescending( x =>
                                    {
                                        Dictionary<string, int> temp = x.Value;
                                        int sum = temp.Sum(y => y.Value);
                                        return sum;
                                    })
                .ToDictionary(x => x.Key, x => x.Value)
                .First()
                .Key;

            int totalPoints = users.First(x => x.Key == bestCandidateName).Value.Sum(x => x.Value);

            Console.WriteLine($"Best candidate is {bestCandidateName} with total {totalPoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var kvp in users)
            {
                Console.WriteLine(kvp.Key);

                foreach (var secondKvp in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {secondKvp.Key} -> {secondKvp.Value}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> users = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] userInfo = command.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = userInfo[0];

                if (userInfo[1] == "banned")
                {
                    users.Remove(username);
                    continue;
                }

                string language = userInfo[1];
                int points = int.Parse(userInfo[2]);

                if (!users.ContainsKey(username))
                {
                    users[username] = points;
                }
                else
                {
                    if (users[username] < points)
                    {
                        users[username] = points;
                    }
                }

                if (!submissions.ContainsKey(language))
                {
                    submissions[language] = 0;
                }

                submissions[language]++;
            }

            Console.WriteLine("Results:");

            foreach (var kvp in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}

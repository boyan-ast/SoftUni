using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, Dictionary<string, int>>();
            var userStatistics = new Dictionary<string, int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] userInfo = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string username = userInfo[0];
                string contest = userInfo[1];
                int points = int.Parse(userInfo[2]);

                int oldPoints = 0;

                bool hasToChangePoints = false;
                bool hasLessPoints = false;

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest].ContainsKey(username))
                    {
                        if (contests[contest][username] < points)
                        {
                            oldPoints = contests[contest][username];
                            contests[contest][username] = points;
                            hasToChangePoints = true;
                        }
                        else
                        {
                            hasLessPoints = true;
                        }
                    }
                    else if (!contests[contest].ContainsKey(username))
                    {
                        contests[contest].Add(username, points);
                    }
                }
                else
                {
                    contests.Add(contest, new Dictionary<string, int>());
                    contests[contest].Add(username, points);
                }

                if (!userStatistics.ContainsKey(username))
                {
                    userStatistics[username] = points;
                }
                else
                {
                    if (hasLessPoints)
                    {
                        continue;
                    }

                    if (hasToChangePoints)
                    {
                        userStatistics[username] -= oldPoints;
                    }

                    userStatistics[username] += points;
                }
            }

            foreach (var kvp in contests)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");

                int count = 1;

                foreach (var kvpValue in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{count}. {kvpValue.Key} <::> {kvpValue.Value}");
                    count++;
                }
            }

            Console.WriteLine("Individual standings:");

            int place = 1;

            foreach (var kvp in userStatistics.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{place}. {kvp.Key} -> {kvp.Value}");
                place++;
            }
        }
    }
}

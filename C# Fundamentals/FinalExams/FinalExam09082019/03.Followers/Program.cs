using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            var followers = new Dictionary<string, Dictionary<string, int>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Log out")
            {
                string[] tokens = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string username = tokens[1];

                if (action == "New follower")
                {
                    if (!followers.ContainsKey(username))
                    {
                        followers[username] = new Dictionary<string, int>
                        {
                            { "likes", 0 },
                            { "comments", 0 }
                        };
                    }
                }
                else if (action == "Like")
                {
                    int count = int.Parse(tokens[2]);

                    if (followers.ContainsKey(username))
                    {
                        followers[username]["likes"] += count;
                    }
                    else
                    {
                        followers[username] = new Dictionary<string, int>
                        {
                            { "likes", count },
                            { "comments", 0 }
                        };
                    }
                }
                else if (action == "Comment")
                {
                    if (followers.ContainsKey(username))
                    {
                        followers[username]["comments"]++;
                    }
                    else
                    {
                        followers[username] = new Dictionary<string, int>
                        {
                            { "likes", 0},
                            { "comments", 1}
                        };
                    }
                }
                else if (action == "Blocked")
                {
                    if (followers.ContainsKey(username))
                    {
                        followers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
            }

            var orderedFollowers = followers
                .OrderByDescending(x => x.Value["likes"])
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => (x.Value["likes"] + x.Value["comments"]));

            Console.WriteLine($"{orderedFollowers.Count} followers");

            foreach (var kvp in orderedFollowers)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}

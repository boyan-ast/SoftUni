using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs.Length == 4)
                {
                    string name = commandArgs[0];

                    if (!vloggers.ContainsKey(name))
                    {                        
                        vloggers[name] = new Dictionary<string, HashSet<string>>()
                        {
                            { "followers", new HashSet<string>() },
                            { "following", new HashSet<string>() }
                        };
                    }
                }
                else if (commandArgs.Length == 3)
                {
                    string firstVlogger = commandArgs[0];
                    string secondVlogger = commandArgs[2];

                    if (firstVlogger == secondVlogger || 
                        !vloggers.ContainsKey(firstVlogger) ||
                        !vloggers.ContainsKey(secondVlogger))
                    {
                        continue;
                    }

                    vloggers[firstVlogger]["following"].Add(secondVlogger);
                    vloggers[secondVlogger]["followers"].Add(firstVlogger);
                }

            }

                Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var orderedVloggers = vloggers
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            int count = 0;            

            foreach (var vlogger in orderedVloggers)
            {
                Console.WriteLine($"{++count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, " +
                $"{vlogger.Value["following"].Count} following");

                if (count != 1)
                {
                    continue;
                }

                foreach (string follower in vlogger.Value["followers"].OrderBy(x => x))
                {
                    Console.WriteLine($"*  {follower}");
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MobaChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new Dictionary<string, Dictionary<string, int>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Season end")
            {
                string[] commandArgs = command
                    .Split(new string[] { " -> ", " vs " }, StringSplitOptions.RemoveEmptyEntries);

                string player = commandArgs[0];

                if (commandArgs.Length == 3)
                {
                    string position = commandArgs[1];
                    int skill = int.Parse(commandArgs[2]);

                    if (players.ContainsKey(player))
                    {
                        if (players[player].ContainsKey(position))
                        {
                            if (players[player][position] < skill)
                            {
                                players[player][position] = skill;
                            }
                        }
                        else
                        {
                            players[player].Add(position, skill);
                        }
                    }
                    else
                    {
                        players.Add(player, new Dictionary<string, int>());
                        players[player].Add(position, skill);
                    }
                }
                else if (commandArgs.Length == 2)
                {
                    string secondPlayer = commandArgs[1];

                    if (players.ContainsKey(player) && players.ContainsKey(secondPlayer))
                    {
                        bool hasCommonPosition = false;

                        foreach (var kvp in players[player])
                        {
                            string firstPlayerPos = kvp.Key;

                            foreach (var secondKvp in players[secondPlayer])
                            {
                                string secondPlayerPos = secondKvp.Key;

                                if (firstPlayerPos == secondPlayerPos)
                                {
                                    hasCommonPosition = true;
                                    break;
                                }
                            }

                            if (hasCommonPosition)
                            {
                                break;
                            }
                        }

                        if (hasCommonPosition)
                        {
                            int firstPlayerTotalSkill = players[player].Sum(x => x.Value);
                            int secondPlayerTotalSkill = players[secondPlayer].Sum(x => x.Value);

                            if (firstPlayerTotalSkill > secondPlayerTotalSkill)
                            {
                                players.Remove(secondPlayer);
                            }
                            else if (firstPlayerTotalSkill < secondPlayerTotalSkill)
                            {
                                players.Remove(player);
                            }
                        }
                    }
                }
            }

            foreach (var kvp in players.OrderByDescending(x => x.Value.Sum(y => y.Value)).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Sum(x => x.Value)} skill");

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {item.Key} <::> {item.Value}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>(capacity);
        }

        public string Name { get; set; }
        public int Capacity { get; private set; }
        public int Count { get { return roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                return false;
            }

            roster.Remove(player);
            return true;
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player != null && player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player != null && player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string playersClass)
        {
            Player[] players = roster.Where(p => p.Class == playersClass).ToArray();
            roster.RemoveAll(p => p.Class == playersClass);

            return players;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Players in the guild: {Name}");

            foreach (Player player in roster)
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().Trim();
        }
    }
}

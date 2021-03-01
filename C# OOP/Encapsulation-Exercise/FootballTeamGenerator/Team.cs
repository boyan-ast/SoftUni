using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> squad;

        public Team(string name)
        {
            Name = name;
            squad = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Rating
        {
            get
            {
                double result = 0;

                foreach (Player player in squad)
                {
                    result += player.Skill;
                }

                if (squad.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(result / squad.Count);
            }
        }


        public void AddPlayer(Player player)
        {
            squad.Add(player);
        }

        public bool RemovePlayer(string playerName)
        {
            Player selectedPlayer = squad.FirstOrDefault(p => p.Name == playerName);

            return squad.Remove(selectedPlayer);
        }

        //private bool IsExistingPlayer(Player player)
        //{
        //    return squad.FirstOrDefault(x => x.Name == player.Name) != null;
        //}
    }
}

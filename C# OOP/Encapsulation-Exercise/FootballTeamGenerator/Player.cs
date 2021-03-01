using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        internal double Skill 
        { 
            get
            {
                return (Endurance + Sprint + Dribble + Passing + Shooting) * 1.0 / 5;
            }
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

        public int Endurance
        {
            get { return endurance; }
            private set 
            {
                if (IsValidStat(value, "Endurance"))
                {
                    endurance = value;
                }
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (IsValidStat(value, "Dribble"))
                {
                    dribble = value;
                }
            }
        }

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (IsValidStat(value, "Sprint"))
                {
                    sprint = value;
                }
            }
        }

        public int Passing
        {
            get { return passing; }
            private set
            {
                if (IsValidStat(value, "Passing"))
                {
                    passing = value;
                }
            }
        }

        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (IsValidStat(value, "Shooting"))
                {
                    shooting = value;
                }
            }
        }

        private bool IsValidStat(int statValue, string statName)
        {
            if (statValue < 0 || statValue > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }

            return true;
        }

    }
}

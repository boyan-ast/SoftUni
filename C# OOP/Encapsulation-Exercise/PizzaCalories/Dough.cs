using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private double weight;
        private string flourType;
        private string bakingTechnique;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            set
            {
                if (value != "White" && value != "Wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique 
        {
            get => bakingTechnique;
            set
            {
                if (value != "Crispy" && value != "Chewy" && value != "Homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Weight 
        {
            get => weight;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = 2 * Weight;

            if (flourType == "Wholegrain")
            {
                calories *= Wholegrain;
            }
            else if (flourType == "White")
            {
                calories *= White;
            }

            if (bakingTechnique == "Crispy")
            {
                calories *= Crispy;
            }
            else if (bakingTechnique == "Chewy")
            {
                calories *= Chewy;
            }
            else if (bakingTechnique == "Homemade")
            {
                calories *= Homemade;
            }

            return calories;
        }

    }
}

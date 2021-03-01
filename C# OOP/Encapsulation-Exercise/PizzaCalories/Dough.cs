using System;

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
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
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
                if (value.ToLower() != "crispy" 
                    && value.ToLower() != "chewy" 
                    && value.ToLower() != "homemade")
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

            if (FlourType.ToLower() == "wholegrain")
            {
                calories *= Wholegrain;
            }
            else if (FlourType.ToLower() == "white")
            {
                calories *= White;
            }

            if (BakingTechnique.ToLower() == "crispy")
            {
                calories *= Crispy;
            }
            else if (BakingTechnique.ToLower() == "chewy")
            {
                calories *= Chewy;
            }
            else if (BakingTechnique.ToLower() == "homemade")
            {
                calories *= Homemade;
            }

            return calories;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double WhiteFlourModifier = 1.5;
        private const double WholegrainFlourModifier = 1.0;

        private const double CrispyTechniqueModifier = 0.9;
        private const double ChewyTechniqueModifier = 1.1;
        private const double HomemadeTechniqueModifier = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType 
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && 
                    value.ToLower() != "chewy" && 
                    value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight 
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            } 
        }

        public double CaloriesPerGram => 2 * this.FlourModifier() * this.TechniqueModifier();

        private double FlourModifier()
        {
            if (this.FlourType.ToLower() == "white")
            {
                return WhiteFlourModifier;
            }
            else if (this.FlourType.ToLower() == "wholegrain")
            {
                return WholegrainFlourModifier;
            }

            return default;
        }

        private double TechniqueModifier()
        {
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                return CrispyTechniqueModifier;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                return ChewyTechniqueModifier;
            }
            else if (this.BakingTechnique.ToLower() == "homemade")
            {
                return HomemadeTechniqueModifier;
            }

            return default;
        }

    }
}

using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.SumDecorationsComfort();

        public ICollection<IDecoration> Decorations => this.decorations.ToList().AsReadOnly();

        public ICollection<IFish> Fish => this.fish.ToList().AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            //If fish is saltwater, or freshwater check if it is possible to add it

            //if (this.GetType().Name == nameof())
            //{

            //}

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            //???

            string fishes = this.fish.Count > 0 ? 
                $"{string.Join(", ", this.fish.ToList())}" : 
                "none";

            sb.AppendLine($"Fish: {fishes}");

            sb.AppendLine($"Decorations: {this.decorations.Count}");

            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }

        private int SumDecorationsComfort()
        {
            int sum = this.decorations.Sum(d => d.Comfort);

            return sum;
        }
    }
}

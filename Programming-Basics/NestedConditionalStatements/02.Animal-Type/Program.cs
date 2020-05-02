using System;

namespace _02.Animal_Type
{
    class Program
    {
        static void Main(string[] args)
        {
            string animal = Console.ReadLine();

            PrintAnimalType(animal);
        }

        private static void PrintAnimalType(string animal)
        {
            string animalType = string.Empty;

            switch (animal)
            {
                case "dog":
                    animalType = "mammal";
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    animalType = "reptile";
                    break;
                default:
                    animalType = "unknown";
                    break;
            }

            Console.WriteLine(animalType);
        }
    }
}

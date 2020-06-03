using System;

namespace _03.FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double cardPrice = 0;

            switch (sport)
            {
                case "Gym":
                    switch (gender)
                    {
                        case 'm':
                            cardPrice = 42;
                            break;
                        case 'f':
                            cardPrice = 35;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Boxing":
                    switch (gender)
                    {
                        case 'm':
                            cardPrice = 41;
                            break;
                        case 'f':
                            cardPrice = 37;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Yoga":
                    switch (gender)
                    {
                        case 'm':
                            cardPrice = 45;
                            break;
                        case 'f':
                            cardPrice = 42;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Zumba":
                    switch (gender)
                    {
                        case 'm':
                            cardPrice = 34;
                            break;
                        case 'f':
                            cardPrice = 31;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Dances":
                    switch (gender)
                    {
                        case 'm':
                            cardPrice = 51;
                            break;
                        case 'f':
                            cardPrice = 53;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Pilates":
                    switch (gender)
                    {
                        case 'm':
                            cardPrice = 39;
                            break;
                        case 'f':
                            cardPrice = 37;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            if (age <= 19)
            {
                cardPrice *= 0.8;
            }

            if (cardPrice <= budget)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${(cardPrice - budget):f2} more.");
            }

        }
    }
}

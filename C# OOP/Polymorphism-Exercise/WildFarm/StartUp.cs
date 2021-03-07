using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                string[] foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);

                Food food = null;

                if (foodType == nameof(Vegetable))
                {
                    food = new Vegetable(foodQuantity);
                }
                else if (foodType == nameof(Meat))
                {
                    food = new Meat(foodQuantity);
                }
                else if (foodType == nameof(Fruit))
                {
                    food = new Fruit(foodQuantity);
                }
                else if (foodType == nameof(Seeds))
                {
                    food = new Seeds(foodQuantity);
                }
                                                               
                Animal animal = null;

                if (type == nameof(Hen))
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Hen(name, weight, wingSize);
                }
                else if (type == nameof(Owl))
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Owl(name, weight, wingSize);
                }
                else if (type == nameof(Mouse))
                {
                    string livingRegion = animalInfo[3];
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (type == nameof(Cat))
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == nameof(Dog))
                {
                    string livingRegion = animalInfo[3];
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (type == nameof(Tiger))
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                }

                Console.WriteLine(animal.ProduceSound());

                animals.Add(animal);

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}

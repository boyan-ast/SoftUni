using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> allCars = new List<Car>(n);

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car()
                {
                    Model = carInfo[0],
                    Mileage = int.Parse(carInfo[1]),
                    Fuel = int.Parse(carInfo[2])
                };

                allCars.Add(car);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] tokens = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string model = tokens[1];

                Car selectedCar = allCars.FirstOrDefault(x => x.Model == model);

                if (action == "Drive")
                {
                    int distance = int.Parse(tokens[2]);
                    int fuel = int.Parse(tokens[3]);

                    if (selectedCar.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        selectedCar.Mileage += distance;
                        selectedCar.Fuel -= fuel;

                        Console.WriteLine($"{model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (selectedCar.Mileage >= 100_000)
                        {
                            allCars.Remove(selectedCar);
                            Console.WriteLine($"Time to sell the {model}!");
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    int amount = int.Parse(tokens[2]);

                    if (selectedCar.Fuel + amount > 75)
                    {
                        amount = 75 - selectedCar.Fuel;
                    }

                    selectedCar.Fuel += amount;

                    Console.WriteLine($"{model} refueled with {amount} liters");
                }
                else if (action == "Revert")
                {
                    int amount = int.Parse(tokens[2]);

                    if (selectedCar.Mileage - amount < 10_000)
                    {
                        selectedCar.Mileage = 10_000;
                    }
                    else
                    {
                        selectedCar.Mileage -= amount;

                        Console.WriteLine($"{model} mileage decreased by {amount} kilometers");
                    }
                }
            }

            foreach (Car car in allCars.OrderByDescending(c => c.Mileage).ThenBy(c => c.Model))
            {
                Console.WriteLine(car);
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public override string ToString()
        {
            return $"{Model} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
}

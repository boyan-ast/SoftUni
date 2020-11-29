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

                string model = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                Car car = new Car(model, mileage, fuel);
                allCars.Add(car);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commandArgs = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string model = commandArgs[1];

                Car existingCar = allCars.First(x => x.Model == model);

                if (action == "Drive")
                {
                    int distance = int.Parse(commandArgs[2]);
                    int fuel = int.Parse(commandArgs[3]);

                    if (existingCar.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        existingCar.Fuel -= fuel;
                        existingCar.Mileage += distance;
                        Console.WriteLine($"{existingCar.Model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (existingCar.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {existingCar.Model}!");
                            allCars.Remove(existingCar);
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    int amount = int.Parse(commandArgs[2]);

                    if (existingCar.Fuel + amount > 75)
                    {
                        amount = 75 - existingCar.Fuel;
                    }

                    existingCar.Fuel += amount;

                    Console.WriteLine($"{existingCar.Model} refueled with {amount} liters");
                }
                else if (action == "Revert")
                {
                    int kmAmount = int.Parse(commandArgs[2]);

                    if (existingCar.Mileage - kmAmount < 10000)
                    {
                        existingCar.Mileage = 10000;
                    }
                    else
                    {
                        existingCar.Mileage -= kmAmount;
                        Console.WriteLine($"{existingCar.Model} mileage decreased by {kmAmount} kilometers");
                    }
                }
            }

            foreach (Car car in allCars.OrderByDescending(x => x.Mileage).ThenBy(x => x.Model))
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

        public Car(string model, int mileage, int fuel)
        {
            Model = model;
            Mileage = mileage;
            Fuel = fuel;
        }

        public override string ToString()
        {
            return $"{Model} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
}

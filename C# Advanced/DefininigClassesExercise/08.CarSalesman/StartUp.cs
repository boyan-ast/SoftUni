using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>(n);

            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(engineData[0], int.Parse(engineData[1]));

                if (engineData.Length == 4)
                {
                    engine.Displacement = int.Parse(engineData[2]);
                    engine.Efficiency = engineData[3];
                }
                else if (engineData.Length == 3)
                {
                    if(int.TryParse(engineData[2], out int displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = engineData[2];
                    }
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> allCars = new List<Car>(m);

            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine selectedEngine = engines.FirstOrDefault(e => e.Model == engineModel);

                Car car = new Car(model, selectedEngine);

                if (carInfo.Length == 4)
                {
                    car.Weight = int.Parse(carInfo[2]);
                    car.Color = carInfo[3];
                }
                else if (carInfo.Length == 3)
                {
                    if (int.TryParse(carInfo[2], out int weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carInfo[2];
                    }
                }

                allCars.Add(car);
            }

            foreach (Car car in allCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

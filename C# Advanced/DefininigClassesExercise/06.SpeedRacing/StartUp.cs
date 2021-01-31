using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Car[] allCars = new Car[n];

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(
                    carInfo[0], 
                    double.Parse(carInfo[1]), 
                    double.Parse(carInfo[2]));

                allCars[i] = car;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] driveInfo = command.Split();
                string model = driveInfo[1];
                double amountOfKm = double.Parse(driveInfo[2]);

                Car selectedCar = allCars.FirstOrDefault(c => c.Model == model);

                selectedCar.DriveCar(amountOfKm);
            }

            foreach (Car car in allCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }
        public int Count 
        { 
            get
            {
                return cars.Count;
            }
        }

        public string AddCar(Car car)
        {
            Car existingCar = cars
                .FirstOrDefault(c => c.RegistrationNumber == car.RegistrationNumber);

            if (existingCar != null)
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car existingCar = cars
                .FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (existingCar == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(existingCar);

            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber) =>
            cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            List<Car> carsToRemove = cars
                .Where(c => registrationNumbers.Contains(c.RegistrationNumber))
                .ToList();

            foreach (Car car in carsToRemove)
            {
                cars.Remove(car);
            }
        }

    }
}

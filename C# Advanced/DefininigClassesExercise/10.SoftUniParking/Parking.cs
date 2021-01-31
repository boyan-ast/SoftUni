using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            Cars = new List<Car>(capacity);
        }

        public List<Car> Cars { get; set; }
        public int Count
        {
            get
            {
                return Cars.Count;
            }
        }

        public string AddCar(Car car)
        {
            if (CarExists(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (Cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!CarExists(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.RemoveAll(c => c.RegistrationNumber == registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string number in registrationNumbers)
            {
                RemoveCar(number);
            }
        }

        private bool CarExists(string registrationNumber)
        {
            return Cars.Any(c => c.RegistrationNumber == registrationNumber);
        }
    }
}

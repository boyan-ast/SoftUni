using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] carInfo = command.Split(", ");

                if (carInfo[0] == "IN")
                {
                    carNumbers.Add(carInfo[1]);
                }
                else if (carInfo[0] == "OUT")
                {
                    carNumbers.Remove(carInfo[1]);
                }
            }

            if (carNumbers.Count > 0)
            {
                foreach (string car in carNumbers)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

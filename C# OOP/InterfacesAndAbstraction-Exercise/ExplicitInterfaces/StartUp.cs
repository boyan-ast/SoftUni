using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;
using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            List<Citizen> citizens = new List<Citizen>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] citizenInfo = command.Split();

                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);

                Citizen cititzen = new Citizen(name, country, age);

                citizens.Add(cititzen);                
            }

            foreach (Citizen citizen in citizens)
            {
                IPerson person = citizen;
                Console.WriteLine(person.GetName());

                IResident resident = citizen;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}

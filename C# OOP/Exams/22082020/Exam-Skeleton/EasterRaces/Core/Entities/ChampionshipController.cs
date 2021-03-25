using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<ICar> cars;
        private IRepository<IDriver> drivers;
        private IRepository<IRace> races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver selectedDriver = drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            ICar selectedCar = cars.GetAll().FirstOrDefault(c => c.Model == carModel);

            if (selectedDriver is null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (selectedCar is null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            selectedDriver.AddCar(selectedCar);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace selectedRace = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);
            IDriver selectedDriver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);

            if (selectedRace is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (selectedDriver is null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            selectedRace.AddDriver(selectedDriver);

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetAll().Any(c => c.Model == model))
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.cars.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            IDriver driver = new Driver(driverName);

            drivers.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetAll().Any(r => r.Name == name))
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            this.races.Add(new Race(name, laps));

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);

            if (race is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            Dictionary<string, double> participants = new Dictionary<string, double>();

            foreach (IDriver driver in race.Drivers)
            {
                participants[driver.Name] = driver.Car.CalculateRacePoints(race.Laps);
            }

            List<string> winners = participants.OrderByDescending(x => x.Value).Select(p => p.Key).Take(3).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {winners[0]} wins {race.Name} race.");
            sb.AppendLine($"Driver {winners[1]} is second in {race.Name} race.");
            sb.AppendLine($"Driver {winners[2]} is third in {race.Name} race.");

            this.races.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}

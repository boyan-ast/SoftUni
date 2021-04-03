using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitDriver driver;
        private UnitCar car;

        [SetUp]
        public void Setup()
        {
            this.car = new UnitCar("Model", 101, 1700);
            this.driver = new UnitDriver("Driver", this.car);
            this.race = new RaceEntry();
        }

        [Test]
        public void CtorWorks()
        {
            Assert.That(this.race.Counter, Is.EqualTo(0));
        }

        [Test]
        public void AddNullDriverThrows()
        {
            Assert.Throws<InvalidOperationException>(() => this.race.AddDriver(null));
        }

        [Test]
        public void AddExistingThrows()
        {
            this.race.AddDriver(this.driver);

            Assert.Throws<InvalidOperationException>(() => this.race.AddDriver(this.driver));
        }

        [Test]
        public void AddIncreasesCounter()
        {
            this.race.AddDriver(this.driver);

            Assert.That(this.race.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddReturnsString()
        {
            string expected = $"Driver {this.driver.Name} added in race.";

            string result = this.race.AddDriver(this.driver);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CalcThrowsWithLessParticipants()
        {
            Assert.Throws<InvalidOperationException>(() => this.race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalcWorks()
        {
            UnitCar second = new UnitCar("Second", 150, 1600);
            UnitCar third = new UnitCar("Second", 150, 1600);

            List<UnitCar> cars = new List<UnitCar>() { car, second, third };

            double expected = cars.Average(c => c.HorsePower);

            this.race.AddDriver(this.driver);
            this.race.AddDriver(new UnitDriver("Second", second));
            this.race.AddDriver(new UnitDriver("Third", third));

            double result = this.race.CalculateAverageHorsePower();

            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
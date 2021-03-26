using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry drivers;
        private UnitDriver driver;
        private UnitCar car;

        [SetUp]
        public void Setup()
        {
            this.drivers = new RaceEntry();
            this.car = new UnitCar("TestModel", 101, 1600);
            this.driver = new UnitDriver("Test", this.car);
        }

        [Test]
        public void Counter_ShouldBeZero_WhenConstructorCalled()
        {
            Assert.That(this.drivers.Counter, Is.EqualTo(0));
        }

        [Test]
        public void AddDriver_ShouldThrowException_WhenNullGiven()
        {
            Assert.Throws<InvalidOperationException>(() => this.drivers.AddDriver(null));
        }

        [Test]
        public void AddDriver_ShouldThrowException_WhenDriverExists()
        {
            this.drivers.AddDriver(this.driver);

            Assert.Throws<InvalidOperationException>(() => this.drivers.AddDriver(this.driver));
        }

        [Test]
        public void AddDriver_ShouldAddIncreaseCounter_WhenDriverAdded()
        {
            this.drivers.AddDriver(this.driver);

            Assert.That(this.drivers.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriver_ShouldReturnCorrectMessage_WhenDriverAdded()
        {
            string message = this.drivers.AddDriver(this.driver);
            string expectedMessage = $"Driver {this.driver.Name} added in race.";

            Assert.That(message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void CalculateAverageHoursePower_ShouldThrowException_WhenParticipantsAreNotEnough()
        {
            this.drivers.AddDriver(this.driver);

            Assert.Throws<InvalidOperationException>(() => this.drivers.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHoursePower_ShouldReturnCorrectResult()
        {
            int firstHoursePower = 80;
            int secondHoursePower = 200;
            int thirdHoursePower = 160;

            List<int> values = new List<int>() { firstHoursePower, secondHoursePower, thirdHoursePower };
            double average = values.Average();

            UnitDriver first = new UnitDriver("Test1", new UnitCar("First", firstHoursePower, 1000));
            UnitDriver second = new UnitDriver("Test2", new UnitCar("Second", secondHoursePower, 1000));
            UnitDriver third = new UnitDriver("Test3", new UnitCar("Third", thirdHoursePower, 1000));

            this.drivers.AddDriver(first);
            this.drivers.AddDriver(second);
            this.drivers.AddDriver(third);

            Assert.That(this.drivers.CalculateAverageHorsePower(), Is.EqualTo(average));
        }

    }
}
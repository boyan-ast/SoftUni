using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private string make = "VW";
        private string model = "Golf";
        private double fuelConsumption = 5;
        private double zeroFuelAmount = 0;
        private double fuelCapacity = 70;


        [SetUp]
        public void Setup()
        {
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void ConstructorsShouldProduceCarWithCorrectFuelAmount()
        {
            Assert.That(this.car.FuelAmount, Is.EqualTo(this.zeroFuelAmount));
        }

        [Test]
        public void ConstructorsShouldProduceCarWithCorrectMake()
        {
            Assert.That(this.car.Make, Is.EqualTo(this.make));
        }

        [Test]
        public void ConstructorsShouldProduceCarWithCorrectModel()
        {
            Assert.That(this.car.Model, Is.EqualTo(this.model));
        }

        [Test]
        public void ConstructorsShouldProduceCarWithCorrectFuelConsumption()
        {
            Assert.That(this.car.FuelConsumption, Is.EqualTo(this.fuelConsumption));
        }

        [Test]
        public void ConstructorsShouldProduceCarWithCorrectFuelCapacity()
        {
            Assert.That(this.car.FuelCapacity, Is.EqualTo(this.fuelCapacity));
        }

        [Test]
        public void SettingNullOrEmptyMakeShouldThrow()
        {
            Assert.That(() => { car = new Car("", model, fuelConsumption, fuelCapacity); },
                Throws.ArgumentException.With.Message
                .EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void SettingNullOrEmptyModelShouldThrow()
        {
            Assert.That(() => { car = new Car(make, "", fuelConsumption, fuelCapacity); },
                Throws.ArgumentException.With.Message
                .EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void SettingZeroOrNegativeConsumptionShouldThrow()
        {
            Assert.That(() => { car = new Car(make, model, 0, fuelCapacity); },
                Throws.ArgumentException.With.Message
                .EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void SettingZeroOrNegativeCapacityShouldThrow()
        {
            Assert.That(() => { car = new Car(make, model, fuelConsumption, -1); },
                Throws.ArgumentException.With.Message
                .EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void RefuelingWithZeroOrNegativeAmountShouldThrow()
        {
            double fuelToRefuel = -10;

            Assert.That(() => { this.car.Refuel(fuelToRefuel); },
                Throws.ArgumentException.With.Message
                .EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void RefuelingShouldIncreaseFuelAmountCorrectly()
        {
            double fuelToRefuel = 5;

            this.car.Refuel(fuelToRefuel);

            Assert.That(this.car.FuelAmount, Is.EqualTo(this.zeroFuelAmount + fuelToRefuel));
        }

        [Test]
        public void RefuelingWithMoreThanCapacityShouldSetAmountEqualToCapacity()
        {
            double fuelToRefuel = 80;

            this.car.Refuel(fuelToRefuel);

            Assert.That(this.car.FuelAmount, Is.EqualTo(this.fuelCapacity));
        }

        [Test]
        public void DrivingLongerThanPossibleDistanceShouldThrow()
        {
            double distance = 2000;

            Assert.That(() => { this.car.Drive(distance); },
                Throws.InvalidOperationException.With.Message
                .EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void DrivingShouldDecreaseFuelAmountCorrectly()
        {
            double carFuelAmount = 50;
            double distance = 100;

            this.car.Refuel(carFuelAmount);

            this.car.Drive(distance);

            double fuelNeeded = (distance / 100) * this.car.FuelConsumption;

            double expectedResult = carFuelAmount - fuelNeeded;

            Assert.That(this.car.FuelAmount, Is.EqualTo(expectedResult));
        }
    }
}
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager manager;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.manager = new ComputerManager();
            this.computer = new Computer("Test", "Testov", 1051.00m);
        }

        [Test]
        public void ComputerConstructor_ShouldCreateCorrectlySetComputer()
        {
            Assert.That(this.computer.Manufacturer, Is.EqualTo("Test"));
            Assert.That(this.computer.Model, Is.EqualTo("Testov"));
            Assert.That(this.computer.Price, Is.EqualTo(1051.00m));
        }

        [Test]
        public void Constructor_CreatesEmptyCollection()
        {
            Assert.That(this.manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_InitializiesNewCollection()
        {
            List<Computer> computers = new List<Computer>();

            CollectionAssert.AreEquivalent(computers, this.manager.Computers);
        }

        [Test]
        public void AddComputer_ThrowsException_WhenComputerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => { this.manager.AddComputer(null); }, "Can not be null!");
        }

        [Test]
        public void AddComputer_ThrowsException_WhenComputerExists()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() =>
            {
                this.manager.AddComputer(new Computer(this.computer.Manufacturer, this.computer.Model, 200m));
            }, 
            "This computer already exists.");
        }

        [Test]
        public void AddComputer_IncreasesCount_WhenComputerAdded()
        {
            this.manager.AddComputer(this.computer);

            Assert.That(this.manager.Count, Is.EqualTo(1));
            //TODO Has.Member
        }

        [Test]
        public void GetComputer_ThrowsException_WhenManufacturerIsNull()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => { this.manager.GetComputer(null, this.computer.Model); }, "Can not be null!");
        }

        [Test]
        public void GetComputer_ThrowsException_WhenModelIsNull()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => this.manager.GetComputer(this.computer.Manufacturer, null));
        }

        [Test]
        public void GetComputer_ThrowsException_WhenManufacturerAndModelDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.manager
            .GetComputer(this.computer.Manufacturer, this.computer.Model));
        }

        [Test]
        public void GetComputer_ThrowsException_WhenManufacturerDoesntExist()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() => this.manager
            .GetComputer("Unknown", this.computer.Model));
        }

        [Test]
        public void GetComputer_ThrowsException_WhenModelDoesntExist()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() => this.manager
            .GetComputer(this.computer.Manufacturer,"Unknown"));
        }

        [Test]
        public void GetComputer_WorksCorrectly_WhenComputerExists()
        {
            this.manager.AddComputer(this.computer);

            Computer resulted = this.manager
                .GetComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.That(resulted.Manufacturer, Is.EqualTo(this.computer.Manufacturer));
            Assert.That(resulted.Model, Is.EqualTo(this.computer.Model));
            Assert.That(resulted.Price, Is.EqualTo(this.computer.Price));
        }

        [Test]
        public void RemoveComputer_DecreasesCount_WhenComputerRemoved()
        {
            this.manager.AddComputer(this.computer);

            Assert.That(this.manager.Count, Is.EqualTo(1));

            this.manager.RemoveComputer("Test", "Testov");

            Assert.That(this.manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveComputer_ReturnsCorrectComputer_WhenComputerRemoved()
        {
            this.manager.AddComputer(this.computer);

            Computer resulted = this.manager
                .RemoveComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.That(resulted.Manufacturer, Is.EqualTo(this.computer.Manufacturer));
            Assert.That(resulted.Model, Is.EqualTo(this.computer.Model));
            Assert.That(resulted.Price, Is.EqualTo(this.computer.Price));
        }

        [Test]
        public void RemoveComputer_ThrowsException_WhenManufaturerIsNull()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => this.manager.RemoveComputer(null, this.computer.Model));
        }

        [Test]
        public void RemoveComputer_ThrowsException_WhenModelIsNull()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => this.manager.RemoveComputer(this.computer.Manufacturer, null));
        }

        [Test]
        public void RemoveComputer_ThrowsException_WhenComputerDoesntExist()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() => this.manager.RemoveComputer("Test2", "Testov2"));
        }

        [Test]
        public void GetComputersByManufacturer_ThrowsException_WhenNullGiven()
        {
            this.manager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => this.manager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturer_ReturnsCorrectCollection()
        {
            Computer second = new Computer(this.computer.Manufacturer, "Testov2", 2000m);

            this.manager.AddComputer(this.computer);
            this.manager.AddComputer(second);

            ICollection<Computer> expected = new List<Computer>() { this.computer, second };

            ICollection<Computer> result = this.manager.GetComputersByManufacturer(this.computer.Manufacturer);

            CollectionAssert.AreEquivalent(expected, result);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetComputersByManufacturer_ReturnsOnlyTheFilteredResults()
        {
            Computer second = new Computer(this.computer.Manufacturer, "Testov2", 2000m);
            Computer third = new Computer("Different", "Testov2", 100m);

            this.manager.AddComputer(this.computer);
            this.manager.AddComputer(second);
            this.manager.AddComputer(third);

            ICollection<Computer> expected = new List<Computer>() { this.computer, second };

            ICollection<Computer> result = this.manager.GetComputersByManufacturer(this.computer.Manufacturer);

            CollectionAssert.AreEquivalent(expected, result);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetComputersByManufacturer_ReturnsZero_WhenNoMatches()
        {
            Computer second = new Computer(this.computer.Manufacturer, "Testov2", 2000m);
            Computer third = new Computer("Different", "Testov2", 100m);

            this.manager.AddComputer(this.computer);
            this.manager.AddComputer(second);
            this.manager.AddComputer(third);

            ICollection<Computer> result = this.manager.GetComputersByManufacturer("other");

            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}
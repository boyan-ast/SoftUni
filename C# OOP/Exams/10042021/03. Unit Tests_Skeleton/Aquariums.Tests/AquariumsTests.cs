namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private string name = "Test";
        private int capacity = 3;

        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium(name, capacity);
        }

        [Test]
        public void NullNameThrows()
        {
            Assert.Throws<ArgumentNullException>(() => this.aquarium = new Aquarium(null, this.capacity));
        }

        [Test]
        public void EmptyNameThrows()
        {
            Assert.Throws<ArgumentNullException>(() => this.aquarium = new Aquarium("", this.capacity));
        }

        [Test]
        public void NameIsCorrect()
        {
            Assert.That(this.aquarium.Name, Is.EqualTo(this.name));
        }

        [Test]
        public void NegativeCapacityThrows()
        {
            Assert.Throws<ArgumentException>(() => this.aquarium = new Aquarium(this.name, -10));
        }

        [Test]
        public void CapacityIsCorrect()
        {
            Assert.That(this.aquarium.Capacity, Is.EqualTo(this.capacity));
        }

        [Test]
        public void InitalCountIsZero()
        {
            Assert.That(this.aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddFishThrowsWhenFull()
        {
            this.aquarium.Add(new Fish("First"));
            this.aquarium.Add(new Fish("Second"));
            this.aquarium.Add(new Fish("Third"));

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(new Fish("fourth")));
        }

        [Test]
        public void AddFishWorks()
        {
            this.aquarium.Add(new Fish("First"));
            this.aquarium.Add(new Fish("Second"));

            Assert.That(this.aquarium.Count, Is.EqualTo(2));
        }

        [Test]
        public void RemoveNullFishThrows()
        {
            this.aquarium.Add(new Fish("First"));

            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Second"));
        }

        [Test]
        public void RemoveFishWorks()
        {
            this.aquarium.Add(new Fish("First"));
            this.aquarium.Add(new Fish("Second"));
            this.aquarium.Add(new Fish("Third"));

            this.aquarium.RemoveFish("Second");
            this.aquarium.RemoveFish("Third");

            Assert.That(this.aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void SellNullFishThrows()
        {
            this.aquarium.Add(new Fish("First"));
            this.aquarium.Add(new Fish("Second"));

            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("Third"));
        }

        [Test]
        public void SellWorks()
        {
            this.aquarium.Add(new Fish("First"));
            this.aquarium.Add(new Fish("Second"));

            Fish fish = new Fish("Third");

            this.aquarium.Add(fish);

            Fish result = this.aquarium.SellFish(fish.Name);

            Assert.That(result.Name, Is.EqualTo(fish.Name));
            Assert.That(result.Available, Is.False);
        }

        [Test]
        public void ReportWorks()
        {
            this.aquarium.Add(new Fish("First"));
            this.aquarium.Add(new Fish("Second"));
            this.aquarium.Add(new Fish("Third"));

            string names = "First, Second, Third";

            string expected = $"Fish available at {this.aquarium.Name}: {names}";

            string result = this.aquarium.Report();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

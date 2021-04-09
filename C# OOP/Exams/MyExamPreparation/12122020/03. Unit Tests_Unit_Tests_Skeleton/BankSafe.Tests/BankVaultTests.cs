using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            this.vault = new BankVault();
            this.item = new Item("Owner", "1");
        }

        [Test]
        public void CtorInitializesVaultCells()
        {
            Assert.That(this.vault.VaultCells, Is.Not.Null);
        }

        [Test]
        public void CtorCreatesVaultWithCorrectCells()
        {
            Dictionary<string, Item> dict = new Dictionary<string, Item>()
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null}
            };

            List<string> expectedKeys = dict.Keys.ToList();

            List<string> keys = this.vault.VaultCells.Keys.ToList();

            CollectionAssert.AreEquivalent(expectedKeys, keys);
        }

        [Test]
        public void AddItem_Throws_CellIncorrect()
        {
            Assert.Throws<ArgumentException>(() => this.vault.AddItem("X1", this.item));
        }

        [Test]
        public void AddItem_Throws_WhenCellIsNotEmpty()
        {
            this.vault.AddItem("A1", this.item);

            Assert.Throws<ArgumentException>(() => this.vault.AddItem("A1", new Item("item", "100")));
        }

        [Test]
        public void AddItem_Throws_WhenCellExists()
        {
            this.vault.AddItem("A1", this.item);

            Assert.Throws<InvalidOperationException>(() => this.vault.AddItem("C1", this.item));
        }

        [Test]
        public void AddItem_Works()
        {
            this.vault.AddItem("A1", this.item);

            Assert.That(this.vault.VaultCells["A1"], Is.EqualTo(this.item));
        }

        [Test]
        public void AddItem_ReturnsString()
        {
            string result = this.vault.AddItem("A1", this.item);

            string expected = $"Item:{this.item.ItemId} saved successfully!";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RemoveItem_Throws_CellDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.vault.RemoveItem("X1", this.item));
        }

        [Test]
        public void RemoveItem_Throws_ItemIsNotInIt()
        {
            Assert.Throws<ArgumentException>(() => this.vault.RemoveItem("A1", this.item));
        }

        [Test]
        public void RemoveItem_Works()
        {
            this.vault.AddItem("A1", this.item);

            this.vault.RemoveItem("A1", this.item);

            Assert.That(this.vault.VaultCells["A1"], Is.Null);
        }

        [Test]
        public void RemoveItem_ReturnsString()
        {
            this.vault.AddItem("A1", this.item);

            string result = this.vault.RemoveItem("A1", this.item);

            string expected = $"Remove item:{this.item.ItemId} successfully!";

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
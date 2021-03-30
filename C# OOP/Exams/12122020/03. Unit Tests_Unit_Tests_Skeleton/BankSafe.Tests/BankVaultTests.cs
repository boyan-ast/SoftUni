using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Dictionary<string, Item> items;
        private Item item;

        [SetUp]
        public void Setup()
        {
            this.items = new Dictionary<string, Item>
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
                {"C4", null},
            };
            this.vault = new BankVault();
            this.item = new Item("Test", "test");
        }

        [Test]
        public void Constructor_CreatesDictionaryWithCountEqualTo12()
        {
            Assert.That(this.vault.VaultCells.Count, Is.EqualTo(this.items.Count));
        }

        [Test]
        public void Counstructor_CreatesCollectionEquivalletToDictionary()
        {
            CollectionAssert.AreEquivalent(this.vault.VaultCells, this.items);
        }

        [Test]
        public void AddItem_ShouldThrowException_WhenTryingToAddItemInNonExistantCell()
        {
            Assert.Throws<ArgumentException>(() => this.vault.AddItem("D100", this.item));
        }

        [Test]
        public void AddItem_ShouldThrowException_WhenTryingToAddItemInTakenCell()
        {
            this.vault.AddItem("A1", this.item);

            Assert.Throws<ArgumentException>(() => this.vault.AddItem("A1", new Item("TestTwo", "testTwo")));
        }

        [Test]
        public void AddItem_ThrowsException_WhenItemExistInAnyCell()
        {
            this.vault.AddItem("A1", this.item);

            Assert.Throws<InvalidOperationException>(() => this.vault.AddItem("A2", new Item("TestName", this.item.ItemId)));
        }

        //[Test]
        //public void AddItem_ShouldAddItemToVault_WhenItemIsCorrect()
        //{
        //    this.vault.AddItem("A1", this.item);

        //    Assert.That(this.vault.VaultCells.Any(x => x?.Value.ItemId == this.item.ItemId), Is.True);
        //}

        [Test]
        public void AddItem_ShouldReturnCorrectString_WhenItemAdded()
        {
            string result = this.vault.AddItem("A1", this.item);

            Assert.That(result, Is.EqualTo($"Item:{this.item.ItemId} saved successfully!"));
        }

        [Test]
        public void AddItem_ShouldIncreaseTheCountOfNonNullVaultCells_WhenItemAdded()
        {
            this.vault.AddItem("A1", this.item);
            Assert.That(this.vault.VaultCells.Values.Where(v => v != null).Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveItem_ShouldThrowException_WhenCellDoesntExist()
        {
            this.vault.AddItem("A1", this.item);

            Assert.Throws<ArgumentException>(() => this.vault.RemoveItem("D100", item));
        }

        [Test]
        public void RemoveItem_ShouldThrowException_WhenTheItemIsNotInTheCell()
        {
            Assert.Throws<ArgumentException>(() => this.vault.RemoveItem("A1", this.item));
        }

        [Test]
        public void RemoveItem_ShouldIncreseTheNullValues_WhenItemIsRemoved()
        {
            this.vault.AddItem("A1", this.item);

            this.vault.RemoveItem("A1", this.item);

            Assert.That(this.vault.VaultCells.Values.Where(v => v == null).Count, Is.EqualTo(12));
        }

        [Test]
        public void RemoveItem_ShouldReturnTheCorrectString_WhenItemRemoved()
        {
            this.vault.AddItem("A1", this.item);

            string result = this.vault.RemoveItem("A1", this.item);
            string expected = $"Remove item:{item.ItemId} successfully!";

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
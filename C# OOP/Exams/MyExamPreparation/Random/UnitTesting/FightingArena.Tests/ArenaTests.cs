using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior attacker;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            attacker = new Warrior("Attacker", 100, 100);
        }

        [Test]
        public void ConstructorInitializeWarriors()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void Constructor_ShouldCreateEmptyWarriorsCollection()
        {
            CollectionAssert.AreEqual(new List<Warrior>(), arena.Warriors);
        }

        [Test]
        public void Warriors_IsCorrectCollection()
        {
            Warrior first = new Warrior("First", 100, 100);
            Warrior second = new Warrior("Second", 200, 100);
            Warrior third = new Warrior("Third", 300, 100);

            List<Warrior> warriors = new List<Warrior>()
            {
                first,
                second,
                third
            };

            this.arena.Enroll(first);
            this.arena.Enroll(second);
            this.arena.Enroll(third);

            CollectionAssert.AreEquivalent(warriors, arena.Warriors);
        }

        [Test]
        public void Count_ShouldBeZero_WhenArenaInitialized()
        {
            Assert.That(arena.Count, Is.Zero);
        }

        [Test]
        public void Enroll_IncreasesCount_WhenWarriorEnrolled()
        {
            arena.Enroll(attacker);

            Assert.That(arena.Count, Is.EqualTo(1));
        }


        [Test]
        public void Enroll_ThrowsException_WhenWarriorNameExists()
        {
            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior(attacker.Name, 200, 300)));
        }

        [Test]
        public void Enroll_AddsWarrior_ToWarriorsList()
        {
            arena.Enroll(attacker);

            string addedName = arena.Warriors.ElementAt(0).Name;
            int addedDamage = arena.Warriors.ElementAt(0).Damage;
            int addedHp = arena.Warriors.ElementAt(0).HP;

            Assert.That(addedName, Is.EqualTo(attacker.Name));
            Assert.That(addedDamage, Is.EqualTo(attacker.Damage));
            Assert.That(addedHp, Is.EqualTo(attacker.HP));
        }
    

        [Test]
        public void Fight_ThrowsException_WhenAttackerIsNotEnrolled()
        {
            Warrior defender = new Warrior("Defender", 100, 200);

            arena.Enroll(defender);

            Assert.That(() => { this.arena.Fight(this.attacker.Name, defender.Name); },
                Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name {attacker.Name} enrolled for the fights!"));
        }

        [Test]
        public void Fight_ThrowsException_WhenDefenderIsNotEnrolled()
        {
            Warrior defender = new Warrior("Defender", 100, 200);

            arena.Enroll(attacker);

            Assert.That(() => { this.arena.Fight(this.attacker.Name, defender.Name); },
                Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name {defender.Name} enrolled for the fights!"));
        }

        [Test]
        public void Fight_ThrowsException_WhenAttackerAndDefenderAreNotEnrolled()
        {
            Assert.That(() => { this.arena.Fight(attacker.Name, "Defender"); },
                Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name Defender enrolled for the fights!"));
        }

        [Test]
        public void Fight_DecreasesDefenderHp_WhenBothWarriorsExist()
        {
            Warrior defender = new Warrior("Defender", 50, 200);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expected = defender.HP - attacker.Damage;

            arena.Fight(attacker.Name, defender.Name);

            Assert.That(defender.HP, Is.EqualTo(expected));
            Assert.That(attacker.HP, Is.EqualTo(50));
        }
    }
}

using FightingArena;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private List<Warrior> warriors = new List<Warrior>();
        private Arena arena;
        private Warrior warrior;
        private Warrior defender;

        private string warriorName = "Attacker";
        private int warriorDamage = 10;
        private int warriorHp = 100;

        private string defenderName = "Defender";
        private int defenderDamage = 20;
        private int defenderHp = 200;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior(this.warriorName, this.warriorDamage, this.warriorHp);
            this.defender = new Warrior(this.defenderName, this.defenderDamage, this.defenderHp);
        }

        [Test]
        public void ConstructoShouldCreateInstanceOfEmptyWarriorlist()
        {
            CollectionAssert.AreEqual(new List<Warrior>(), this.arena.Warriors);
        }

        [Test]
        public void ConstroctorShouldCreateInstanceWithZeroCount()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));                
        }

        [Test]
        public void WarriorsShouldReturnCorrectCollection()
        {
            List<Warrior> group = new List<Warrior>()
            {
                new Warrior("Test1", 1, 1),
                new Warrior("Test2", 1, 1),
                new Warrior("Test3", 1, 1)
            };

            foreach (Warrior item in group)
            {
                this.arena.Enroll(item);
            }

            CollectionAssert.AreEqual(group, this.arena.Warriors);
        }

        [Test]
        public void EnrollShouldAddWarriorToWarriorsList()
        {
            this.arena.Enroll(this.warrior);

            string addedName = this.arena.Warriors.ElementAt(0).Name;
            int addedDamage = this.arena.Warriors.ElementAt(0).Damage;
            int addedHp = this.arena.Warriors.ElementAt(0).HP;

            Assert.That(addedName, Is.EqualTo(this.warriorName));
            Assert.That(addedDamage, Is.EqualTo(this.warriorDamage));
            Assert.That(addedHp, Is.EqualTo(this.warriorHp));
        }

        [Test]
        public void AddingExistingWarriorNameShouldThrow()
        {
            this.arena.Enroll(this.warrior);
            Warrior newWarrior = new Warrior(this.warriorName, 150, 1500);

            Assert.That(() => { this.arena.Enroll(newWarrior); },
                Throws.InvalidOperationException.With.Message
                .EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void EnrollingShouldIncreaseCountWithOne()
        {
            this.arena.Enroll(this.warrior);

            Assert.That(this.arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void CountShouldReturnTheWarriorsNumber()
        {
            Warrior secondWarrior = new Warrior("Second", 200, 2000);

            arena.Enroll(this.warrior);
            arena.Enroll(secondWarrior);

            Assert.That(this.arena.Count, Is.EqualTo(2));
        }

        [Test]
        public void WhenFightingNotExistingAttackerShouldThrow()
        {
            this.arena.Enroll(this.defender);

            Assert.That(() => { this.arena.Fight(this.warriorName, this.defenderName); },
                Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name {this.warriorName} enrolled for the fights!"));
        }

        [Test]
        public void WhenFightingNoExistingDefenderShouldThrow()
        {
            this.arena.Enroll(this.warrior);

            Assert.That(() => { this.arena.Fight(this.warriorName, this.defenderName); },
                Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name {this.defenderName} enrolled for the fights!"));
        }

        [Test]
        public void WhenFightingTwoNotExistngWarriorsShouldThrow()
        {
            Assert.That(() => { this.arena.Fight(this.warriorName, this.defenderName); },
                Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name {this.defenderName} enrolled for the fights!"));
        }
        
        [Test]
        public void WhenFightingWarriorShouldAttackDefender()
        {
            this.arena.Enroll(warrior);
            this.arena.Enroll(defender);

            this.arena.Fight(this.warriorName, this.defenderName);

            Assert.That(this.warrior.HP, Is.EqualTo(this.warriorHp - this.defenderDamage));
            Assert.That(this.defender.HP, Is.EqualTo(this.defenderHp - this.warrior.Damage));

        }
    }
}

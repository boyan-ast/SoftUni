using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior attacker;
        //private Warrior enemy;
        private string correctName = "Test";
        private int correctDamage = 10;
        private int correctHp = 100;

        [SetUp]
        public void Setup()
        {
            this.attacker = new Warrior(correctName, correctDamage, correctHp);
            //this.enemy = new Warrior("Enemy", 20, 200);
        }

        [Test]
        public void Constructor_SetsProperties_Correctly()
        {
            Assert.That(attacker.Name, Is.EqualTo(correctName));
            Assert.That(attacker.Damage, Is.EqualTo(correctDamage));
            Assert.That(attacker.HP, Is.EqualTo(correctHp));
        }

        [Test]
        public void SettingNullOrWhiteSpaceNameShouldThrow()
        {
            Assert.That(() => { this.attacker = new Warrior(" ", correctDamage, correctHp); },
                Throws.ArgumentException.With.Message
                .EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void SettingNegativeDamageShouldThrow()
        {
            Assert.That(() => { this.attacker = new Warrior(this.correctName, -10, this.correctHp); },
                Throws.ArgumentException.With.Message
                .EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void SettingZeroDamageShouldThrow()
        {
            Assert.That(() => { this.attacker = new Warrior(this.correctName, 0, this.correctHp); },
                Throws.ArgumentException.With.Message
                .EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void SettingNegativeHpShouldThrow()
        {
            Assert.That(() => { this.attacker = new Warrior(this.correctName, this.correctDamage, -100); },
                Throws.ArgumentException.With.Message
                .EqualTo("HP should not be negative!"));
        }

        [Test]
        public void Attack_ThrowsException_WhenAttackerHpIsLessThanMin()
        {
            Warrior weakWarrior = new Warrior("Weaker", correctDamage, 10);

            Assert.Throws<InvalidOperationException>(() => weakWarrior.Attack(attacker));
        }

        [Test]
        public void Attack_ThrowsException_WhenAttackerHpIsEqualToMin()
        {
            Warrior weakWarrior = new Warrior("Weaker", correctDamage, 30);

            Assert.Throws<InvalidOperationException>(() => weakWarrior.Attack(attacker));
        }

        [Test]
        public void Attack_ThrowsException_WhenDefenderHpIsLessThanMin()
        {
            Warrior weakWarrior = new Warrior("Weaker", correctDamage, 20);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(weakWarrior));
        }

        [Test]
        public void Attack_ThrowsException_WhenDefenderHpIsEqualToMin()
        {
            Warrior weakWarrior = new Warrior("Weaker", correctDamage, 30);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(weakWarrior));
        }

        [Test]
        public void Attack_ThrowsException_WhenAttackerHpIsLessThanDefenderDamage()
        {
            Warrior defender = new Warrior("Defender", correctHp + 1, correctHp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_DecreasesAttackerHp()
        {
            int defenderDamage = 40;

            Warrior defender = new Warrior("Defender", defenderDamage, 100);

            int expectedWarriorHp = correctHp - defenderDamage;

            attacker.Attack(defender);

            Assert.That(attacker.HP, Is.EqualTo(expectedWarriorHp));
        }

        [Test]
        public void Attack_MakesDefenderHpEqualToZero_WhenAttackerIsALotStronger()
        {
            this.attacker = new Warrior("Attacker", 100, 200);
            Warrior defender = new Warrior("Defender", 50, 50);

            attacker.Attack(defender);

            Assert.That(defender.HP, Is.EqualTo(0));
            Assert.That(attacker.HP, Is.EqualTo(150));
        }

        [Test]
        public void Attack_DecreasesDefenderHp_WhenAttackerIsStronger()
        {
            this.attacker = new Warrior("Attacker", 100, 200);
            Warrior defender = new Warrior("Defender", 50, 250);

            attacker.Attack(defender);

            Assert.That(defender.HP, Is.EqualTo(150)); 
            Assert.That(attacker.HP, Is.EqualTo(150));
        }
    }
}
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private const int MinAttackHp = 30; 

        private string name = "Test";
        private int damage = 10;
        private int hp = 100;
        private Warrior warrior;
        private Warrior enemy;
        private string enemyName = "TestAttacked";
        private int enemyDamage = 20;
        private int enemyHp = 200;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(this.name, this.damage, this.hp);
            this.enemy = new Warrior(this.enemyName, this.enemyDamage, this.enemyHp);
        }

        [Test]
        public void ConstructorShouldCreateWarriorWithCorrectName()
        {
            Assert.That(this.warrior.Name, Is.EqualTo(this.name));
        }

        [Test]
        public void ConstructorShouldCreateWarriorWithCorrectDamage()
        {
            Assert.That(this.warrior.Damage, Is.EqualTo(this.damage));
        }

        [Test]
        public void ConstructorShouldCreateWarriorWithCorrectHp()
        {
            Assert.That(this.warrior.HP, Is.EqualTo(this.hp));
        }

        [Test]
        public void SettingNullOrWhiteSpaceNameShouldThrow()
        {

            Assert.That(() => { this.warrior = new Warrior(" ", this.damage, this.hp); },
                Throws.ArgumentException.With.Message
                .EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void SettingNegativeDamageShouldThrow()
        {
            Assert.That(() => { this.warrior = new Warrior(this.name, -10, this.hp); },
                Throws.ArgumentException.With.Message
                .EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void SettingZeroDamageShouldThrow()
        {
            Assert.That(() => { this.warrior = new Warrior(this.name, 0, this.hp); },
                Throws.ArgumentException.With.Message
                .EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void SettingNegativeHpShouldThrow()
        {
            Assert.That(() => { this.warrior = new Warrior(this.name, this.damage, -100); },
                Throws.ArgumentException.With.Message
                .EqualTo("HP should not be negative!"));
        }

        [Test]
        public void AttackingWithEqualOrLowerThanMinHpShouldThrow()
        {
            this.warrior = new Warrior(this.name, this.damage, 20);

            Assert.That(() => { this.warrior.Attack(this.enemy); },
                Throws.InvalidOperationException.With.Message
                .EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackingEnemyWithEqualOrLowerThanMinHpShouldThrow()
        {
            this.enemy = new Warrior(this.enemyName, this.enemyDamage, 25);

            Assert.That(() => { this.warrior.Attack(this.enemy); },
                Throws.InvalidOperationException.With.Message
                .EqualTo($"Enemy HP must be greater than {MinAttackHp} in order to attack him!"));
        }

        [Test]
        public void AttackingWithHpLowerThanEnemyDamageShouldThrow()
        {
            this.enemy = new Warrior(this.enemyName, 120, this.enemyHp);

            Assert.That(() => { this.warrior.Attack(this.enemy); },
                Throws.InvalidOperationException.With.Message
                .EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackingEnemyShouldDecreaseHpCorrectly()
        {
            this.warrior.Attack(this.enemy);

            Assert.That(this.warrior.HP, Is.EqualTo(this.hp - this.enemyDamage));
        }

        [Test]
        public void AttackigWeakerEnemyShouldKillHim()
        {
            this.warrior = new Warrior(this.name, 300, this.hp);

            this.warrior.Attack(this.enemy);

            Assert.That(this.enemy.HP, Is.EqualTo(0));
        }

        [Test]
        public void AttacingEnemyShouldDecreaseHisHpCorrectly()
        {
            this.warrior.Attack(this.enemy);

            Assert.That(this.enemy.HP, Is.EqualTo(this.enemyHp - this.damage));
        }
    }
}
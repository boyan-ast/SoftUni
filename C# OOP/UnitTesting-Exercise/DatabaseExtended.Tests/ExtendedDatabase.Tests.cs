using NUnit.Framework;
using ExtendedDatabaseNamespace;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person[] inputDataFullDatabase = new Person[]
        {
            new Person(1, "Test1"),
            new Person(2, "Test2"),
            new Person(3, "Test3"),
            new Person(4, "Test4"),
            new Person(5, "Test5"),
            new Person(6, "Test6"),
            new Person(7, "Test7"),
            new Person(8, "Test8"),
            new Person(9, "Test9"),
            new Person(10, "Test10"),
            new Person(11, "Test11"),
            new Person(12, "Test12"),
            new Person(13, "Test13"),
            new Person(14, "Test14"),
            new Person(15, "Test15"),
            new Person(16, "Test16"),
        };

        private Person[] inputDataMoreThanCapacity = new Person[]
        {
            new Person(1, "Test1"),
            new Person(2, "Test2"),
            new Person(3, "Test3"),
            new Person(4, "Test4"),
            new Person(5, "Test5"),
            new Person(6, "Test6"),
            new Person(7, "Test7"),
            new Person(8, "Test8"),
            new Person(9, "Test9"),
            new Person(10, "Test10"),
            new Person(11, "Test11"),
            new Person(12, "Test12"),
            new Person(13, "Test13"),
            new Person(14, "Test14"),
            new Person(15, "Test15"),
            new Person(16, "Test16"),
            new Person(17, "Test17"),
        };

        private Person[] persons = new Person[]
        {
            new Person(101, "Test101"),
            new Person(102, "Test102"),
            new Person(103, "Test103"),
            new Person(104, "Test104"),
        };

        private Person person = new Person(99, "Test99");
        public int capacity = 16;

        private ExtendedDatabase fullDatabase;
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.fullDatabase = new ExtendedDatabase(inputDataFullDatabase);
            this.database = new ExtendedDatabase(persons);
        }

        [Test]
        public void CountGetterShouldReturnTheNumberOfPersons()
        {
            Assert.That(this.database.Count, Is.EqualTo(this.persons.Length));
        }

        [Test]
        public void AddingMoreThanCapacityPeopleShouldThrow()
        {
            Assert.That(() => { new ExtendedDatabase(inputDataMoreThanCapacity); }, 
                Throws.ArgumentException.With.Message
                .EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void AddingPersonToFullDatabaseShouldThrow()
        {
            Assert.That(() => { this.fullDatabase.Add(person); }, 
                Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddingExistingPersonUsernameShouldThrow()
        {
            string existingPersonUsername = this.persons[0].UserName;
            long uniqueId = 100;

            Assert.That(() =>
            {
                this.database.Add(new Person(uniqueId, existingPersonUsername));
            }, 
            Throws.InvalidOperationException.With.Message
            .EqualTo("There is already user with this username!"));
        }
        
        [Test]
        public void AddingExistingPersonIdShouldThrow()
        {
            long existingId = this.persons[0].Id;
            string uniqueUsername = "Test100";

            Assert.That(() =>
            {
                this.database.Add(new Person(existingId, uniqueUsername));
            },
            Throws.InvalidOperationException.With.Message
            .EqualTo("There is already user with this Id!") );
        }

        [Test]
        public void AddingPersonShouldIncreaseTheCount()
        {
            this.database.Add(person);

            Assert.That(this.database.Count, Is.EqualTo(this.persons.Length + 1));
        }

        [Test]
        public void RemoveInEmptyDatabaseShouldThrow()
        {
            ExtendedDatabase emptyDb = new ExtendedDatabase();

            Assert.That(() => { emptyDb.Remove(); }, Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldDecreaseCountByOne()
        {
            this.database.Remove();

            Assert.That(this.database.Count, Is.EqualTo(this.persons.Length - 1));
        }

        [Test]
        public void SearchingPersonByNullNameShouldThrow()
        {
            try
            {
                this.database.FindByUsername("");
            }
            catch (ArgumentNullException ex)
            {

                Assert.AreEqual("Username parameter is null!", ex.ParamName);
            }
        }

        [Test]
        public void SearchingNonExistingPersonShouldThrow()
        {
            string notExisting = "Test100";

            Assert.That(() => { this.database.FindByUsername(notExisting); }, 
                Throws.InvalidOperationException.With.Message
                .EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FoundPersonByUsernameShouldBeCorrect()
        {
            long correctId = persons[0].Id;
            string correctUsername = persons[0].UserName;

            Person foundPerson = this.database.FindByUsername(persons[0].UserName);

            Assert.That(foundPerson.UserName, Is.EqualTo(correctUsername));
            Assert.That(foundPerson.Id, Is.EqualTo(correctId));
        }

        [Test]
        public void SearchingByNegativeIdShouldThrow()
        {
            long invalidId = -1;

            try
            {
                this.database.FindById(invalidId);
            }
            catch (ArgumentOutOfRangeException ex)
            {

                Assert.AreEqual("Id should be a positive number!", ex.ParamName);
            }
        }

        [Test]
        public void SearchingByNotExistingIdShouldThrow()
        {
            long notExistingId = 100;

            Assert.That(() => { this.database.FindById(notExistingId); }, 
                Throws.InvalidOperationException.With.Message
                .EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FoundPersonByIdShouldBeCorrect()
        {
            long correctId = persons[0].Id;
            string correctUsername = persons[0].UserName;

            Person foundPerson = this.database.FindById(persons[0].Id);

            Assert.That(foundPerson.UserName, Is.EqualTo(correctUsername));
            Assert.That(foundPerson.Id, Is.EqualTo(correctId));
        }
    }
}
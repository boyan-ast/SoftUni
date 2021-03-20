using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private int[] inputDataFullDatabase =
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,
                        10, 11, 12, 13, 14, 15, 16};
        private int[] numbers = new int[] { 100, 101, 102, 103, 104 };
        private int number = 17;
        public int capacity = 16;
        private Database.Database fullDatabase;
        private Database.Database database;

        [SetUp]
        public void SetUp()
        {
            this.fullDatabase = new Database.Database(inputDataFullDatabase);
            this.database = new Database.Database(numbers);
        }


        [Test]
        public void CountGetterShoutReturnTheNumberOfElemens()
        {
            Assert.That(database.Count, Is.EqualTo(numbers.Length));
        }

        [Test]
        public void AddingElementToAFullDatabaseShouldThrow()
        {
            Assert.That(() => { this.fullDatabase.Add(number); },
                Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddingElementShouldIncreaseTheCount()
        {
            this.database.Add(number);

            Assert.That(this.database.Count, 
                Is.EqualTo(this.numbers.Length + 1));
        }

        [Test]
        public void NewElementShouldBeAddedInTheEnd()
        {
            this.database.Add(number);
            int[] databaseAsArray = this.database.Fetch();

            Assert.That(databaseAsArray[databaseAsArray.Length - 1], Is.EqualTo(number));
        }

        [Test]
        public void RemovingElementOfEmptyDatabaseShouldThrow()
        {
            var emptyDb = new Database.Database();

            Assert.That(() => { emptyDb.Remove(); }, 
                Throws.InvalidOperationException.With.Message
                .EqualTo("The collection is empty!"));
        }

        [Test]
        public void RemovingElementShouldDecreaseCount()
        {
            this.database.Remove();

            Assert.That(this.database.Count, Is.EqualTo(this.numbers.Length - 1));
        }

        [Test]
        public void FetchShouldReturnTheElementsInArray()
        {
            int[] coppied = this.database.Fetch();            

            CollectionAssert.AreEqual(numbers, coppied);

        }
    }
}
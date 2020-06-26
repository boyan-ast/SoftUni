using System;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[]
                {   "Excellent product.",
                    "Such a great product.",
                    "I always use that product.",
                    "Best product of its category.",
                    "Exceptional product.",
                    "I can’t live without this product." };

            string[] events = new string[]
            {   "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!" };

            string[] authors = new string[]
                {   "Diana",
                    "Petya",
                    "Stella",
                    "Elena",
                    "Katya",
                    "Iva",
                    "Annie",
                    "Eva" };
            string[] cities = new string[]
                {   "Burgas",
                    "Sofia",
                    "Plovdiv",
                    "Varna",
                    "Ruse" };

            int messages = int.Parse(Console.ReadLine());

            for (int i = 0; i < messages; i++)
            {
                Random rnd = new Random();

                int phraseIndex = rnd.Next(phrases.Length);
                int eventIndex = rnd.Next(events.Length);
                int authorIndex = rnd.Next(authors.Length);
                int cityIndex = rnd.Next(cities.Length);

                Console.WriteLine($"{phrases[phraseIndex]} {events[eventIndex]} {authors[authorIndex]} – {cities[cityIndex]}");
            }
        }
    }
}

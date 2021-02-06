using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var comparator = new EqualityScale<int>(066, 066);

            Console.WriteLine(comparator.AreEqual());
        }
    }
}

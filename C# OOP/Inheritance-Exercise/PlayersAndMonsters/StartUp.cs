using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Hero("basicHero", 1));
            Console.WriteLine(new Elf("elfka", 12));
            Console.WriteLine(new BladeKnight("hurricane", 123));
        }
    }
}
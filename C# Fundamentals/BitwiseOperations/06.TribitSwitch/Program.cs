using System;

namespace _06.TribitSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int result = n ^ (7 << p);

            Console.WriteLine(result);
        }
    }
}

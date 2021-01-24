using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    string line = string.Empty;
                    int count = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{++count}. {line}");
                    }
                }
            }
        }
    }
}

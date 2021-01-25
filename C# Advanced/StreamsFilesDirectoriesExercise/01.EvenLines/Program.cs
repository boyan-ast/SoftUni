using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                int count = 0;
                string line = string.Empty;
                string pattern = @"[\-,.!?]";

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (count % 2 == 0)
                        {
                            line = Regex.Replace(line, pattern, "@");
                            string[] lineArray = line
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Reverse()
                                .ToArray();

                            writer.WriteLine(string.Join(" ", lineArray));
                        }

                        count++;
                    }
                }
            }
        }
    }
}

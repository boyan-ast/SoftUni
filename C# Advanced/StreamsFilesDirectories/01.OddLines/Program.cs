using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader(@"../../../Input.txt"))
            {
                int count = 0;

                string line = streamReader.ReadLine();

                using (StreamWriter streamWriter = new StreamWriter(@"../../../output.txt"))
                {
                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            streamWriter.WriteLine(line);
                        }

                        line = streamReader.ReadLine();
                        count++;
                    }
                }
            }
        }
    }
}



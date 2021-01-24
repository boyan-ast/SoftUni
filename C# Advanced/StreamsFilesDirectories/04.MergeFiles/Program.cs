using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader firstReader = new StreamReader("../../../FileOne.txt"))
            {
                using (StreamReader secondReader = new StreamReader("../../../FileTwo.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                    {
                        string firstLine = string.Empty;
                        string secondLine = string.Empty;

                        while ((firstLine = firstReader.ReadLine()) != null && (secondLine = secondReader.ReadLine()) != null)
                        {
                            writer.WriteLine(firstLine);
                            writer.WriteLine(secondLine);
                        }

                        if (firstLine != null)
                        {
                            writer.WriteLine(firstLine);
                        }

                        if (secondLine != null)
                        {
                            writer.WriteLine(secondLine);
                        }

                        while ((firstLine = firstReader.ReadLine()) != null)
                        {
                            writer.WriteLine(firstLine);
                        }

                        while ((secondLine = secondReader.ReadLine()) != null)
                        {
                            writer.WriteLine(firstLine);
                        }
                    }
                }
            }
        }
    }
}

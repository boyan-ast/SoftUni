using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            string fullFileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);

            string fileName = fullFileName.Substring(0, fullFileName.IndexOf('.'));

            string extension = fullFileName.Substring(fullFileName.IndexOf('.') + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}

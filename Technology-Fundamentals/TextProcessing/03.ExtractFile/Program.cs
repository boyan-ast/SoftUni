using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            int nameStartIndex = path.LastIndexOf('\\') + 1;

            string[] nameAndExtension = path.Substring(nameStartIndex).Split('.');

            string fileName = nameAndExtension[0];
            string extension = nameAndExtension[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}

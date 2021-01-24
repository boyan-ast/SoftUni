using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = "../../../TestFolder";

            string[] files = Directory.GetFiles(folderPath);

            double size = 0;

            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);
                size += file.Length;
            }

            Console.WriteLine(size / 1024 / 1024);
        }
    }
}

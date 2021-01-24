using System;
using System.IO;

namespace _07.RecursiveDirectories_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"D:\Games";
            Console.WriteLine(ScanFolderRecursively(folderPath, 0));
        }

        static double ScanFolderRecursively(string folderPath, int identation)
        {
            string[] filePaths = Directory.GetFiles(folderPath);
            double size = 0;

            foreach (string file in filePaths)
            {
                FileInfo info = new FileInfo(file);
                Console.WriteLine($"{new string(' ', identation)}{info.FullName}");

                size += info.Length;
            }

            string[] directories = Directory.GetDirectories(folderPath);

            foreach (string directory in directories)
            {
                 size += ScanFolderRecursively(directory, identation + 4);
            }      
            

            return size / 1024.00 / 1024.00;
        }
    }
}

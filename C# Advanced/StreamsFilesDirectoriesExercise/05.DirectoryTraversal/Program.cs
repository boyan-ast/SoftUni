using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string[] filePaths = Directory.GetFiles("../../../");

            Dictionary<string, Dictionary<string, double>> report = new Dictionary<string, Dictionary<string, double>>();
             
            foreach (string filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                string extension = fileInfo.Extension;
                string name = fileInfo.Name;
                double size = (double)fileInfo.Length / 1000;

                if (!report.ContainsKey(extension))
                {
                    report.Add(extension, new Dictionary<string, double>());
                }

                //No duplicate file names - no need to check for existing key in the nested dictionary.

                report[extension].Add(name, size);
            }

            Dictionary<string, Dictionary<string, double>> orderedReport = report
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{desktopPath}report.txt");            

            using (StreamWriter writer = new  StreamWriter($"{desktopPath}\\report.txt"))
            {
                foreach (var kvp in orderedReport)
                {
                    writer.WriteLine($"{kvp.Key}");

                    foreach (var file in kvp.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }

        }
    }
}

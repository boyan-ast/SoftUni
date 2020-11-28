using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string barcodePattern = @"^@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+$";

            Regex barcodeRegex = new Regex(barcodePattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (barcodeRegex.IsMatch(input))
                {
                    StringBuilder group = new StringBuilder();

                    for (int j = 0; j < input.Length; j++)
                    {
                        if (char.IsDigit(input[j]))
                        {
                            group.Append(input[j].ToString());
                        }
                    }

                    if (group.Length == 0)
                    {
                        group.Append("00");
                    }

                    Console.WriteLine($"Product group: {group}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}

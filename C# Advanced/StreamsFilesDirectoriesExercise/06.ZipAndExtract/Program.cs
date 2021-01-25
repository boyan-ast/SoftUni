using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("../../../inputDirectory", "../../../result.zip");
            ZipFile.ExtractToDirectory("../../../result.zip", "../../../extracted");
        }
    }
}

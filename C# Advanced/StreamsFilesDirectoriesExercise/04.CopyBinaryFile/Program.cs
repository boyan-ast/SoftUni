using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream readStream = new FileStream("../../../copyMe.png", FileMode.Open, FileAccess.Read))
            {
                using (FileStream writeStream= new FileStream("../../../copiedFile.png", FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = 0;

                    while ((bytesRead = readStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}

using System;
using System.IO;

namespace _05.SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream streamReader = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                int parts = 4;
                long partSize = streamReader.Length / parts;

                for (int i = 0; i < parts; i++)
                {
                    byte[] buffer = new byte[1];
                    int count = 0;

                    using (FileStream streamWriter = new FileStream($"../../../slice-{i + 1}.txt", FileMode.Create, FileAccess.Write))
                    {
                        while (count < partSize && streamReader.Position != streamReader.Length)
                        {
                            streamReader.Read(buffer, 0, buffer.Length);
                            streamWriter.Write(buffer, 0, buffer.Length);
                            count++;
                        }

                        if (streamReader.Position != streamReader.Length && i == 3)
                        {
                            long remainingBytes = streamReader.Length - streamReader.Position;
                            byte[] lastBuffer = new byte[remainingBytes];
                            streamReader.Read(lastBuffer, 0, lastBuffer.Length);
                            streamWriter.Write(lastBuffer, 0, lastBuffer.Length);
                        }
                    }
                }

            }
        }
    }
}

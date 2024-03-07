using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpConsole.Samples.Unmanaged
{
    class Streams
    {
        public static void Main()
        {
            UsingEquivalentPresentation();
            UsingPresentation();

            FileStreamPresentation(); //can work with any file binary and text
            StreamReaderWriterPresentation(); //designed for text based files
        }

        private static void FileStreamPresentation()
        {
            var filePath = @"C:\Temp\ac_tmp.txt";
            var destinationFilePath = @"C:\Temp\ac_tmp1.txt";

            try
            {
                using (var fileStream = File.OpenRead(filePath))
                using (var destinationFileStream = File.OpenWrite(destinationFilePath))
                {
                    var length = fileStream.Length;

                    var strBuilder = new StringBuilder();
                    var byteFile = new List<byte>();

                    var encoding = new UTF8Encoding();
                    var buffer = new byte[64];
                    while (fileStream.Read(buffer, 0, buffer.Length) > 0)
                    {
                        var temp = encoding.GetString(buffer); // reading text file with FileStream
                        strBuilder.Append(temp);

                        byteFile.AddRange(buffer); //this will contain all definition of file in bytes

                        destinationFileStream.Write(buffer, 0, buffer.Length); //appending text to a file

                    }

                    
                    Console.WriteLine(strBuilder.ToString());
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(encoding.GetString(byteFile.ToArray()));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void StreamReaderWriterPresentation()
        {
            Console.Clear();
            var filePath = @"C:\Temp\ac_tmp.txt";
            var destinationFilePath = @"C:\Temp\ac_tmp1.txt";

            try
            {
                using (var reader = File.OpenText(filePath))
                using (var writer = File.CreateText(destinationFilePath))
                {
                    //reader.ReadToEnd() //read it all
                    while (!reader.EndOfStream)
                    {
                        var temp = reader.ReadLine(); // reading text file with FileStream
                        writer.WriteLine(temp);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void UsingPresentation()
        {
            using (var stream = new MemoryStream())
            {
                var canRead = stream.CanRead;
            }
        }

        private static void UsingEquivalentPresentation()
        {
            IDisposable disposable = null;

            try
            {
                disposable = new MemoryStream();
                //work with disposable
            }
            finally
            {
                disposable?.Dispose(); //in MemoryStream Close() == Dispose()
            }
        }
    }
}

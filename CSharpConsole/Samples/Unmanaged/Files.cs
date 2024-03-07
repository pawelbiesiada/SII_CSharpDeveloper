using System;
using System.IO;

namespace CSharpConsole.Samples.Unmanaged
{
    class Files
    {
        public static void Main()
        {
            try
            {
                FileClassPresentation();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            FileInfoClassPresentation();

            DirectoryClassPresentation();
            Console.ReadKey();
        }

        private static void FileClassPresentation()
        {
            //var path = "C:\\Temp\\test.txt";
            var path = @"C:\Temp\test.txt"; // absolute path
            var relativePath = "test.txt"; //relative path
            //Assembly.GetExecutingAssembly().Location // gets path, which is a base for relative path

            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                File.AppendAllText(path, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.");

                var path2 = Path.Combine(
                    Path.GetDirectoryName(path),
                    Path.GetFileNameWithoutExtension(path),
                    "temp",
                    Path.GetExtension(path));
                File.Copy(path, path2);  //FileNotFoundException


                //AccessViolationException

                if (File.Exists(path2))
                {
                    File.Delete(path2);
                }

                if (File.Exists(path))
                {
                    File.Delete(path);
                }


            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine("File was not found");
            }
            finally
            {
                //
            }


            Console.WriteLine();

        }

        private static void FileInfoClassPresentation()
        {
            var path = @"C:\Temp\test.txt";

            try
            {
                var file = new FileInfo(path);

                if (!file.Exists)
                {
                    file.Create();
                }
                var fileDirectoryName = file.DirectoryName;
                
                file.AppendText().Write("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
                
                var path2 = Path.Combine(
                    Path.GetDirectoryName(path),
                    Path.GetFileNameWithoutExtension(path),
                    "temp",
                    Path.GetExtension(path));
                file.CopyTo(path2);

                if (File.Exists(path2))
                {
                    File.Delete(path2);
                }

                if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void DirectoryClassPresentation()
        {
            var path = @"C:\Temp\";

            try
            {
                
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var subDirectories = Directory.GetDirectories(path);

                var textFiles = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

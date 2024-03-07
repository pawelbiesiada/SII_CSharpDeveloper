using System;

namespace CSharpConsole.Samples.Patterns
{
    interface IFacade
    {
        void GetFile();
        void ProcessFile();
    }

    class Facade : IFacade
    {
        private readonly FileManager _fileManager;
        private readonly Reader _reader;
        private readonly Processor _processor;

        public Facade(FileManager fileManager, Reader reader, Processor processor)
        {
            _fileManager = fileManager;
            _reader = reader;
            _processor = processor;
        }

        public void GetFile()
        {
            _fileManager.SaveFile();
            _reader.ReadFile();
        }

        public void ProcessFile()
        {
            _processor.ProcessFile();
        }
    }

    class FileManager
    {
        public void SaveFile()
        {
            Console.WriteLine("File Saved.");
        }
    }

    class Reader
    {
        public void ReadFile()
        {
            Console.WriteLine("File read.");
        }
    }

    class Processor
    {
        public void ProcessFile()
        {
            Console.WriteLine("File processed");
        }
    }
}

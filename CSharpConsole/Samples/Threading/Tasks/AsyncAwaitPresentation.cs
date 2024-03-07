using System;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.Threading.Tasks
{
    internal class AsyncAwaitPresentation
    {
        private static void Main(string[] args)
        {
            var sample = new AsyncAwaitPresentation();
            var task = sample.ExecuteAsync();
            task.Wait();
        }

        private async Task ExecuteAsync()
        {
            var value = "Pawel";
            var result = await GetNameAsync(value);
            Console.WriteLine("More processing is pending.");            
            Console.WriteLine(result);
            Console.WriteLine("Awaited for asynchronous call to complete.");

            Console.ReadKey();
        }

        private async Task<string> GetNameAsync(string myName)
        {
            var result = await Task.Factory.StartNew((str) => PrintName(str.ToString()), myName);
            Console.WriteLine("Doing some more work in async method.");
            return result;
        }

        private string PrintName(string name)
        {
            Task.Delay(3000).Wait();
            return string.Format("Hi {0}!!!", name);
        }
    }
}

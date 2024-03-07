using System;
using System.Threading;

namespace CSharpConsole.Samples.Threading.Threads
{
    internal class ForegroundThread
    {
        private static void Main(string[] args)
        {
            var foregroundThread = new Thread(LongRunningMethod) { IsBackground = false };

            Console.WriteLine("Running method asynchronously in foregroundThread.");
            foregroundThread.Start();
            Console.WriteLine("We are in main method, executing next statements...");
        }

        private static void LongRunningMethod()
        {
            Thread.Sleep(3000);
            Console.WriteLine("LongRunningMethod completed execution on threadId {0}.", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
    }
}

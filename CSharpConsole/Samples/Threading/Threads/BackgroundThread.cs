using System;
using System.Threading;

namespace CSharpConsole.Samples.Threading.Threads
{
    internal class BackgroundThread
    {
        private static void Main(string[] args)
        {
            var backgroundThread = new Thread(LongRunningMethod) { IsBackground = true };
         
            Console.WriteLine("Running method asynchronously in backgroundThread.");
            backgroundThread.Start();
            Console.WriteLine("We are in main method, executing next statements...");
        }

        private static void LongRunningMethod()
        {
            for (int i = 0; i < 50000000; i++)
            {
                Math.Acos(Math.Asin(i));
            }
            Console.WriteLine("LongRunningMethod completed execution on threadId {0}.", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
    }
}

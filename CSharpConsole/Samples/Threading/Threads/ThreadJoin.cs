using System;
using System.Threading;

namespace CSharpConsole.Samples.Threading.Threads
{
    internal class ThreadJoin
    {
        private static void Main(string[] args)
        {
            var sample = new ThreadJoin();
            sample.Execute();
        }

        private void Execute()
        {
            Console.WriteLine("This sample is to present threads synchronization with Join method.");

            var thread1 = new Thread(LongRunningMethod);
            var thread2 = new Thread(LongRunningMethod);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Both threads should complete by now.");
            Console.ReadKey();
        }

        private void LongRunningMethod()
        {
            double result;
            for (int i = 0; i < 5000000; i++)
            {
                result = Math.Acos(Math.Asin(i));
            }
            Console.WriteLine("LongRunningMethod completed execution on threadId {0}.", Thread.CurrentThread.ManagedThreadId);
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.Threading.Threads
{
    internal class ThreadingException
    {
        private static void Main(string[] args)
        {
            var sample = new ThreadingException();
            sample.ExecuteThread();
            sample.ExecuteTask();
            var task = sample.ExecuteAsyncAwait();
            task.Wait();

            Console.ReadKey();
        }

        private void ExecuteThread()
        {
            var t = new Thread(SomeMethod);

            try
            {
                t.Start();
                t.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception type {0}", ex.GetType());
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void ExecuteTask()
        {
            var t = new Task(SomeMethod);
            try
            {
                t.Start();
                t.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception type {0}", ex.GetType());
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        
        private async Task ExecuteAsyncAwait()
        {
            var t = Task.Factory.StartNew(SomeMethod);
            try
            {
                await t;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception type {0}", ex.GetType());
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void SomeMethod()
        {
            Thread.Sleep(100);
            var val = 0;
            double result = 5 / val;
        }
    }
}

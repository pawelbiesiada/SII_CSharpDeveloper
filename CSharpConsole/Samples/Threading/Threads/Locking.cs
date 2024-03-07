using System;
using System.Threading;

namespace CSharpConsole.Samples.Threading.Threads
{
    internal class MonitorLocking
    {
        private readonly object _lockedObject = new object();
        int _commonCounter;
        int _thread1Counter;
        int _thread2Counter;

        private static void Main(string[] args)
        {
            var sample = new MonitorLocking();
            sample.Execute();
        }

        private void Execute()
        {
            var t1 = new Thread(Increment1);
            var t2 = new Thread(Increment2);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Thread1 executed the loop {0:N0} times", _thread1Counter);
            Console.WriteLine("Thread2 executed the loop {0:N0} times", _thread2Counter);
            Console.WriteLine("Both Thread1 & Thread2 executed the loop {0:N0} times", (_thread1Counter + _thread2Counter));
            Console.WriteLine("CommonCounter was increased {0:N0} times", _commonCounter);
            Console.ReadKey();
        }

        private void Increment1()
        {
            while (_commonCounter < 1000000)
            {
                lock (_lockedObject)
                {
                    if (_commonCounter < 1000000)
                    {
                        _commonCounter++;
                        _thread1Counter++;
                    }
                }
            }

        }
        private void Increment2()
        {
            while (_commonCounter < 10000000)
            {
                lock (_lockedObject)
                {
                    if (_commonCounter < 1000000)
                    {
                        _commonCounter++;
                        _thread2Counter++;
                    }
                }
            }
        }


        private void Increment3() //this one is more efficient - locking once
        {
            lock (_lockedObject)
            {
                while (_commonCounter < 10000000)
                {
                    _commonCounter++;
                    _thread2Counter++;
                }
            }
        }

    }
}

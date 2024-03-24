using System;
using System.Threading;

namespace CSharpConsole.Samples.Threading.Threads
{
    class CriticalSectionUnsafe
    {
        int _commonCounter;
        int _thread1Counter;
        int _thread2Counter;

        int _interlockedCommonCounter;

        private static void Main(string[] args)
        {
            var sample = new CriticalSectionUnsafe();
            sample.Execute();
        }

        private void Execute()
        {
            var t1 = new Thread(Increment1);
            var t2= new Thread(Increment2);
            t1.Start();
            t2.Start();

            ///
            ///
            /// 
            Console.WriteLine("");
            ///

            t1.Join();
            t2.Join();

            Console.WriteLine("Thread1 executed the loop {0:N0} times", _thread1Counter);
            Console.WriteLine("Thread2 executed the loop {0:N0} times", _thread2Counter);
            Console.WriteLine("Both Thread1 & Thread2 executed the loop {0:N0} times", (_thread1Counter + _thread2Counter));
            Console.WriteLine("CommonCounter was increased {0:N0} times", _commonCounter);
            Console.WriteLine("_interlockedCommonCounter was increased {0:N0} times", _interlockedCommonCounter);
            Console.ReadKey();
        }

        private object _locker = new object();

        private void Increment1()
        {
            while (_commonCounter < 10_000_000)
            {
                Interlocked.Increment(ref _interlockedCommonCounter);


                lock (_locker)
                {
                    if(_commonCounter < 10_000_000 )
                    {
                        _commonCounter++;
                    }
                    else
                    {
                        return;
                    }
                }
                _thread1Counter++;
            }
        }

        private void Increment2(object obj)
        {
            while (_commonCounter < 10_000_000)
            {
                Interlocked.Increment(ref _interlockedCommonCounter);


                lock (_locker)
                {
                    if (_commonCounter < 10_000_000)
                    {
                        _commonCounter++;
                    }
                    else
                    {
                        return;
                    }
                }
                _thread2Counter++;
            }
        }
    }
}

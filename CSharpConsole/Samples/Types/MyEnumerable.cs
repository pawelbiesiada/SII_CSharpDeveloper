using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace CSharpConsole.Samples.Types
{
    class MyEnumerable
    {
        public MyEnumerable()
        {
        }

        public MyEnumerable(int wait)
        {
            Thread.Sleep(wait);
        }


        private static IEnumerable<MyEnumerable> GetEnumerable()
        {
            yield return new MyEnumerable(1000);
            yield return new MyEnumerable(1000);
            yield return new MyEnumerable(1000);
            yield return new MyEnumerable(1000);
            yield return new MyEnumerable(1000);
            yield return new MyEnumerable(1000);
            yield return new MyEnumerable(1000);
        }
        
        private static IEnumerable<MyEnumerable> GetList() //it does not matter if it is IEnumerable<> or List<>, important is what is underneath
        {
            return new List<MyEnumerable>
            {
                new MyEnumerable(1000),
                new MyEnumerable(1000),
                new MyEnumerable(1000),
                new MyEnumerable(1000),
                new MyEnumerable(1000),
                new MyEnumerable(1000),
                new MyEnumerable(1000)
            };
        }

        public static void Main()
        {
            var timer = Stopwatch.StartNew();

            var enumerable = GetEnumerable();
            Console.WriteLine($"Invoking GetEnumerable took {timer.ElapsedMilliseconds}ms.");
            timer.Restart();
            var count = enumerable.Count();
            Console.WriteLine($"Enumerating enumerable for the first time took {timer.ElapsedMilliseconds}ms.");
            timer.Restart();
            count = enumerable.Count();
            Console.WriteLine($"Enumerating enumerable for the second time took {timer.ElapsedMilliseconds}ms.");
            Console.WriteLine();


            timer.Restart();
            var list = GetList();
            Console.WriteLine($"Invoking GetList took {timer.ElapsedMilliseconds}ms.");
            timer.Restart();
            count = list.Count();
            Console.WriteLine($"Invoking GetList for the first time took {timer.ElapsedMilliseconds}ms.");
            timer.Restart();
            count = list.Count();
            Console.WriteLine($"Invoking GetList for the second time took {timer.ElapsedMilliseconds}ms.");

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Exercises
{
    class ListTest
    {
        public void Test()
        {
            var count = 1_000_000;
            var list = InitList(count);
            var hash = InitHashSet(count);
            
            var checksCount = 10_000;
            var random = new Random();

            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < checksCount; i++)
            {
                var contains = list.Contains(random.Next(0, 2_000_000));
            }
            timer.Stop();
            Console.WriteLine($"List time {timer.ElapsedMilliseconds} ms.");


            timer.Restart();
            for (int i = 0; i < checksCount; i++)
            {
                var contains = hash.Contains(random.Next(0, 2_000_000));
            }
            timer.Stop();
            Console.WriteLine($"Hash time {timer.ElapsedMilliseconds} ms.");

            Console.ReadKey();
        }

        private List<int> InitList(int elementsCount)
        {
            var list = new List<int>();
            for (int i = 0; i < elementsCount; i++)
            {
                list.Add(i);
            }

            return list;
        }
        private HashSet<int> InitHashSet(int elementsCount)
        {
            var list = new HashSet<int>();
            for (int i = 0; i < elementsCount; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}

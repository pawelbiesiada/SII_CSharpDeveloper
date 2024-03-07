using System;
using System.Diagnostics;
using System.Linq;

namespace CSharpConsole.Samples.Threading.Parallels
{
    internal class PlinqPresentation
    {
        private static void Main()
        {
            var sample = new PlinqPresentation();
            sample.Execute();
        }
        private void Execute()
        {
            ProcessData();
            ProcessParallelData();

            Console.ReadKey();
        }

        private void ProcessData()
        {
            // Get a very large array of integers.
            int[] source = Enumerable.Range(1, 100_000_000).ToArray();
            var stopwatch = new Stopwatch();
            // Find the numbers where num % 3 == 0 is true, returned
            // in descending order.
            stopwatch.Start();
            int[] modThreeIsZero = source.Where(n => n % 3 == 0).OrderByDescending(n => n).ToArray();
            Console.WriteLine(
                $"Found {modThreeIsZero.Count()} numbers synchronously that match query in {stopwatch.ElapsedMilliseconds}ms!");
        }
        private void ProcessParallelData()
        {
            // Get a very large array of integers.
            int[] source = Enumerable.Range(1, 100_000_000).ToArray();
            var stopwatch = new Stopwatch();
            // Find the numbers where num % 3 == 0 is true, returned
            // in descending order.
            stopwatch.Start();
            int[] modThreeIsZeroAsync = source
                .AsParallel()
                .WithDegreeOfParallelism(8)
                .Where(n => n % 3 == 0)
                //.AsParallel()
                .OrderByDescending(n => n).ToArray();
            Console.WriteLine(
                $"Found {modThreeIsZeroAsync.Count()} numbers parallely that match query in {stopwatch.ElapsedMilliseconds}ms!");
            stopwatch.Stop();
        }
    }
}

using System;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.Threading.Parallels
{
    internal class ParallelPresentation
    {
        private static void Main()
        {
            var sample = new ParallelPresentation();
            sample.Execute();
        }

        private void Execute()
        {
            Parallel.For(0, 20, new ParallelOptions() {MaxDegreeOfParallelism = 8 }, PrintMessage);
            Console.ReadKey();




            var arr = new int[20];
            for (int i = 0; i < 20; i++)
            {
                arr[i] = i;
            }
            Parallel.ForEach(arr, new ParallelOptions() { MaxDegreeOfParallelism = 8 }, PrintMessage);
            Console.ReadKey();
        }

        private void PrintMessage(int number)
        {
            Console.WriteLine("Executed iteration {0}.", number);
        }
    }
}

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.Threading.Parallels
{
    internal class ParallelPresentation
    {
        #region public stuff

        public static void Main()
        {
            var sample = new ParallelPresentation();
            sample.Execute();
        }

        public void Execute()
        {
            try
            {
                Parallel.For(0, 20, new ParallelOptions() { MaxDegreeOfParallelism = 4 }, PrintMessage);

            }
            catch (AggregateException aex)
            {
                foreach (var ex in aex.InnerExceptions)
                {

                }
            }
            Console.ReadKey();




            var arr = new int[20];
            for (int i = 0; i < 20; i++)
            {
                arr[i] = i;
            }

            var strArray = new string[arr.Length];


            //#warning using if based on release build configuration


            Parallel.ForEach<int>(arr, new ParallelOptions() { MaxDegreeOfParallelism = 8 }, PrintMessage);


            Parallel.Invoke(  () => PrintMessage(3), () => FileDownload("SomePathHere")  );

            Console.ReadKey();
        }

        #endregion


        #region private stuff
        private void FileDownload(string urlPath)
        {

        }

        private void PrintMessage(int number)
        {
            if(number % 3 == 0)
            {
                throw new ArgumentException();
            }

            Console.WriteLine("Executed iteration {0}.", number);
        }


        private void PrintStringMessage(string msg)
        {
            Console.WriteLine("Executed iteration {0}.", msg);
        }

        #endregion
    }
}

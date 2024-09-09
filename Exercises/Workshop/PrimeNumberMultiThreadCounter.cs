using MyExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Workshop
{
    internal class PrimeNumberMultiThreadCounter
    {
        public void Execute()
        {
            //generate numbers
            Random r = new Random();
            List<Task<bool>> tasks = new List<Task<bool>>();

            //create threads
            //execute all threads together
            for (int i = 0; i < 50; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => { return IsPrimeNumber(r.Next(100, 1000)); }));
            }

            //wait for execution simultaneously
            //foreach (Task<bool> task in tasks) 
            //{
            //    task.Wait();
            //}
            Task.WaitAll(tasks.ToArray());

            //count and display how many numbers returned true
            var primeNumbersCount = tasks.Count(t => t.Result == true);

            Console.WriteLine($"We have found {primeNumbersCount} prime numbers" );



        }


        public void ExecuteWithPlinq()
        {
            //generate numbers
            Random r = new Random();
            List<Task<bool>> tasks = new List<Task<bool>>();

            //create threads
            //execute all threads together
            for (int i = 0; i < 50; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => { return IsPrimeNumber(r.Next(100, 1000)); }));
            }

            //wait for execution simultaneously
            //foreach (Task<bool> task in tasks) 
            //{
            //    task.Wait();
            //}
            Task.WaitAll(tasks.ToArray());

            //count and display how many numbers returned true
            var primeNumbersCount = tasks.Count(t => t.Result == true);

            Console.WriteLine($"We have found {primeNumbersCount} prime numbers");



        }


        private static bool IsPrimeNumber(int numberToValidate)
        {
            if (numberToValidate <= 1)
                return false;

            for (int i = 2; i < numberToValidate; i++)
            {
                if (numberToValidate % i == 0) //divides by i fully
                {
                    return false;
                }
            }

            return true;
        }



    }
}

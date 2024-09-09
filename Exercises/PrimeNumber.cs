using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExercises
{
    internal class PrimeNumber
    {
        public static bool IsPrimeNumber(int numberToValidate)
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

        public static void CheckAndPrintPrimeNumberValidation()
        {
            Console.WriteLine("Provide number to validate: ");
            int myint = 0;
            try
            {
                myint = int.Parse(Console.ReadLine());
               // var isPrime = IsPrimeNumber(myint);
             //   var message = isPrime ? "Is prime number" : "Is not a prime number.";
               // Console.WriteLine(message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Provided string was not a valid integer number");
            }

            var wasParsed = int.TryParse(Console.ReadLine(), out myint);
            var isPrime = IsPrimeNumber(myint);
            var message = isPrime ? "Is prime number" : "Is not a prime number.";
            Console.WriteLine(message);
        }
    }
}

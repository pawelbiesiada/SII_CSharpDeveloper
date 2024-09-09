using System;

namespace CSharpConsole.Samples.LINQ
{
    class LambdaExpression
    {
        public delegate int IntOperation(int x, int y);

        static void Main()
        {
            var a = 3;
            var b = 2;

            var myOperation = new IntOperation((x, y) => { return x - y; });
            //myOperation = new IntOperation((x, y) => x - y);
            //myOperation = (x, y) => x - y;

            var result = myOperation.Invoke(a, b); //sum
            Console.WriteLine("Sum on {0} and {1} is {2}", a, b, result);

            myOperation = (x, y) => { Console.WriteLine("sub"); return x - y; };
            result = myOperation.Invoke(a, b); //subtraction
            Console.WriteLine("Subtraction on {0} and {1} is {2}", a, b, result);

            myOperation = (x, y) => 
            { 
                Console.WriteLine("prod"); 
                return x * y; 
            }; //what about += events
            result = myOperation.Invoke(a, b); //product
            Console.WriteLine("Product on {0} and {1} is {2}", a, b, result);

            Func<int, int, int> func = (x, y) => 3;
            func = (x, y) => x * y;
            func = (x, y) =>
            {
                Console.WriteLine("Dividing integers is not very convenient. Think of using doubles or decimals");
                var result = x / (double) y;
                return (int)result;
            };

            Action<int, int> actionGeneric = ((x, y) =>
            {
                Console.WriteLine(result);
                Console.WriteLine(myOperation(x, y));
            });

            Action emptyAction = () => { };
            emptyAction(); // does nothing

           Console.ReadKey();
        }
    }
}

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

            var operation = new IntOperation((x, y) => { return x - y; });
            //operation = new IntOperation((x, y) => x - y);
            //operation = (x, y) => x - y;

            var ret = operation.Invoke(a, b); //sum
            Console.WriteLine("Sum on {0} and {1} is {2}", a, b, ret);

            operation = (x, y) => { Console.WriteLine("sub"); return x - y; };
            ret = operation.Invoke(a, b); //subtraction
            Console.WriteLine("Subtraction on {0} and {1} is {2}", a, b, ret);

            operation = (x, y) => 
            { 
                Console.WriteLine("prod"); 
                return x * y; 
            }; //what about += events
            ret = operation.Invoke(a, b); //product
            Console.WriteLine("Product on {0} and {1} is {2}", a, b, ret);

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
                Console.WriteLine(ret);
                Console.WriteLine(operation(x, y));
            });

            Action emptyAction = () => { };
            emptyAction(); // does nothing

           Console.ReadKey();
        }
    }
}

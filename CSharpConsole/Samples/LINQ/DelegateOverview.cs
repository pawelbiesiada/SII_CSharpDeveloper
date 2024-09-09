using System;

namespace CSharpConsole.Samples.LINQ
{

    internal class DelegateOverview
    {
        public delegate int IntOperation(int x, int y);

        public static void Main()
        {
            DelegatePresentation();

            AnonymousMethodPresentation();

            Console.ReadKey();
        }

        private static void DelegatePresentation()
        {
            var a = 3;
            var b = 2;

            IntOperation myOperation = new IntOperation(SomeFunction);
            //myOperation = SomeFunction; //or this
            //myOperation = Math.Min; // or this

            var ret = myOperation.Invoke(a, b);
            //var ret2 = myOperation(a, b); //shorter version
            Console.WriteLine("Sum on {0} and {1} is {2}", a, b, ret);

            myOperation = Math.Max;
            ret = myOperation.Invoke(a, b);
            Console.WriteLine("Max on {0} and {1} is {2}", a, b, ret);


            Func<int, int, int> myFunc = SomeFunction; //new SomeFunction<int, int, int>(operation);
            Action<string> myAction = Print;
            myAction("Text");


            ExecuteDelegate(myOperation); //you can pass delegate to another method like any reference type variable
        }

        private static void AnonymousMethodPresentation()
        {
            var a = 3;
            var b = 2;

            IntOperation operation = delegate(int p1, int p2)   //cannot use var here, not for anonymous function. We don't know what is the type
            {
                Console.WriteLine("This is the body of anonymous method");
                return p1 + p2;
            };

            var result = operation(a, b);


            var str = $"String defined on the level of the {nameof(AnonymousMethodPresentation)} method.";
            IntOperation productFunc = delegate(int p1, int p2)
            {
                Console.WriteLine(str);
                return p1 * p2;
            };

            result = productFunc(a, b);

            //ExecuteAction(new Action(delegate () { Console.WriteLine("Empty action sample"); }));
            ExecuteAction(delegate () { Console.WriteLine("Empty action sample"); });
            ExecuteAction(delegate () { Console.WriteLine(str); });


            //local function is a new feature of C# 7.0
            void LocalFunction()
            {
                Console.WriteLine("local function body");
            }

            LocalFunction(); //executes locally created methodlike any other method
        }

        private static int SomeFunction(int arg1, int arg2)
        {
            Console.WriteLine($"Executing {nameof(SomeFunction)} with two int parameters");

            return arg1 + arg2;
        }

        private static void Print(string message)
        {
            Console.WriteLine($"Executing {nameof(Print)} with message: {message}");
        }


        private static void ExecuteDelegate(IntOperation someIntOperation)
        {
            someIntOperation(1, 44);
        }

        private static void ExecuteAction(Action someAction)
        {
            someAction();
        }
    }
}

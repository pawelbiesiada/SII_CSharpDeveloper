using System;

namespace CSharpConsole.Samples
{
    class TestStatic
    {
        public void Test()
        {
            //var staticClass = new StaticClass();  invalid declaration
            StaticClass.VoidMethod();
        }
    }

    static class StaticClass
    {
        //private int _counter; //invalid declaration
        private static int _counter;

        public static void VoidMethod()
        {
            var counter = 100;
            Console.WriteLine(counter);
        }

        public static int ReturnCounter() { return _counter++; }

        //void Method() { }   //invalid declaration
        
    }
}

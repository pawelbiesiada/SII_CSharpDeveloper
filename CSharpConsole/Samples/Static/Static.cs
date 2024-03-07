using System;

namespace CSharpConsole.Samples.Static
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
        
        //void Method() { }   //invalid declaration
        
    }
}

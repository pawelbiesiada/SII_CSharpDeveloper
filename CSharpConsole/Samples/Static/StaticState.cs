using System;

namespace CSharpConsole.Samples.Static
{
    public class StaticStateTest
    {
        private static void Main()
        {
            var s1 = new StaticState();
            var s2 = new StaticState();
            var s3 = new StaticState();
            var s4 = new StaticState();


            Console.WriteLine($"Variable s1\tStatic counter:{StaticState.StaticInitializedCounter}\tinstance counter:{s1.InitializedCounter}");
            Console.WriteLine($"Variable s2\tStatic counter:{StaticState.StaticInitializedCounter}\tinstance counter:{s2.InitializedCounter}");
            Console.WriteLine($"Variable s3\tStatic counter:{StaticState.StaticInitializedCounter}\tinstance counter:{s3.InitializedCounter}");
            Console.WriteLine($"Variable s4\tStatic counter:{StaticState.StaticInitializedCounter}\tinstance counter:{s4.InitializedCounter}");
        }
    }

    class StaticState
    {
        public static int StaticInitializedCounter { get; private set; }
        public int InitializedCounter { get; private set; }
        
        public StaticState()
        {
            StaticInitializedCounter++;
            InitializedCounter++;
        }
    }
}

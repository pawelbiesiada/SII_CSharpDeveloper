using System;
using System.Diagnostics;

namespace CSharpConsole.Samples.Debugging
{
    internal class StackTraceSample
    {
        private static void Main(string[] args)
        {
            var localVal = 5;
            try
            {
                if (localVal <= 5)
                {
                    InnerMethod();
                }
                localVal = 7;
            }
            catch (Exception e)
            {
                StackTrace st = new StackTrace(true);
                string indent = "";
                for (int i = 0; i < st.FrameCount; i++)
                {
                    var frame = st.GetFrame(i);
                    Console.WriteLine();
                    Console.WriteLine("****************Frames in Main****************");
                    Console.WriteLine(indent + " Method Name: {0}", frame.GetMethod());
                    Console.WriteLine(indent + " File Name : {0}", frame.GetFileName());
                    Console.WriteLine(indent + " Line Number: {0}", frame.GetFileLineNumber());
                    indent += "  ";
                }
            }
            Console.ReadKey();
        }

        private static void InnerMethod()
        {
            var intermediate = new IntermediateClass();
            intermediate.Excecute();
        }
    }

    internal class IntermediateClass
    {
        public void Excecute()
        {
            var excThrower = new ExceptionThrower();
            excThrower.Throw("Sample Exception");
        }
    }

    internal class ExceptionThrower
    {
        public void Throw(string message)
        {
            try
            {
                throw new Exception(message);
            }
            catch (Exception e)
            {
                StackTrace st = new StackTrace(true);
                string indent = "";
                for (int i = 0; i < st.FrameCount; i++)
                {
                    var frame = st.GetFrame(i);
                    Console.WriteLine();
                    Console.WriteLine(indent + " Method Name: {0}", frame.GetMethod());
                    Console.WriteLine(indent + " File Name : {0}", frame.GetFileName());
                    Console.WriteLine(indent + " Line Number: {0}", frame.GetFileLineNumber());
                    indent += "  ";
                }
                throw e;
            }
        }
    }
}

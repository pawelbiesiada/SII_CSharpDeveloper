using System;
using System.IO;
using CSharpConsole.Exercises;

namespace CSharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
           
        }
    }
}

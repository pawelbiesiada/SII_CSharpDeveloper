using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CSharpConsole.Samples.Reflection
{
    class ReflectionOverview
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            //var assembly = Assembly.LoadFile(@"C:\Temp\SomeLibrary.dll");

            PrintAssemblyDetails(assembly);
            PrintAssemblyTypes(assembly);

            Console.ReadKey();
        }

        private static void PrintAssemblyTypes(Assembly assembly)
        {
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                var method = type.GetMethods().First();

                var prop = type.GetProperties();
                var attr = type.GetCustomAttributes();
            }
        }

        private static void PrintAssemblyDetails(Assembly assembly)
        {
            Console.WriteLine("Assembly Full Name:");
            Console.WriteLine(assembly.FullName);

            AssemblyName assemblyName = assembly.GetName();
            Console.WriteLine("\nName: {0}", assemblyName.Name);
            Console.WriteLine("Version: {0}.{1}", assemblyName.Version.Major, assemblyName.Version.Minor);

            Console.WriteLine("\nAssembly CodeBase:");
            Console.WriteLine(assembly.Location);

            Console.WriteLine("\nAssembly entry point:");
            Console.WriteLine(assembly.EntryPoint);
        }

    }
}

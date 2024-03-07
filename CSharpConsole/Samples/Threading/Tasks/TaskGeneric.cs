using System;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.Threading.Tasks
{
    internal class TaskGeneric
    {
        private static void Main(string[] args)
        {
            var sample = new TaskGeneric();
            sample.Execute();
        }
        private void Execute()
        {
            string name = "Pawel";

            var parameterlessTask = new Task(ParameterlessVoidMethod);
            var parametrizedTask = new Task(VoidMethod, name);
            var task = Task.Factory.StartNew(() => { Task.Delay(1000).Wait(); return "Hello!!!"; });
            task.Wait();
            Console.WriteLine(task.Result);

            

            var parameterlessGenericTask = new Task<string>(ParameterlessMethodReturningParameter);
            var parametrizedGenericTask = new Task<string>(MethodReturningParameter, name);
            var task2 = Task.Factory.StartNew((str) => { Task.Delay(5000).Wait(); return $"Hello {str}!!!";}, name);
            
            task2.Wait();
            Console.WriteLine(task2.Result);
            Console.WriteLine("Ready & Waiting.");
            Console.ReadKey();
        }

        private void ParameterlessVoidMethod()
        {
            Console.WriteLine("Hello!!!");
        }
        private void VoidMethod(object name)
        {
            Console.WriteLine($"Hello {name}!!!");
        }

        private string MethodReturningParameter(object name)
        {
            return $"Hello {name}!!!";
        }

        private string ParameterlessMethodReturningParameter()
        {
            return "Hello!!!";
        }
    }
}

﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.Threading.Tasks
{
    class TasksCancellationToken
    {
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        private static void Main()
        {
            var sample = new TasksCancellationToken();
            sample.Execute();
        }

        private async void Execute()
        {
            var task = Task.Run(Wait);

            try
            {
                Task.Delay(3000).Wait();
                _cts.Cancel(true);
                task.Wait();
                Console.WriteLine("Task completed");
                if (task.Exception != null)
                    throw task.Exception;


                await MyMethodAsync(_cts.Token);
            }
            catch (OperationCanceledException)
            {
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }

        private async Task Wait()
        { 
            await Task.Delay(10000, _cts.Token);
        }

        private async Task MyMethodAsync(CancellationToken ct)
        {
            for (int i = 0; i < 10; i++) 
            {
                Thread.Sleep(1000);

                if(ct.IsCancellationRequested)
                {
                    //rollback

                    return;
                }

                //ct.ThrowIfCancellationRequested();

            }
        }
    }
}

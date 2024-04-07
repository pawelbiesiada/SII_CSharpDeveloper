using AsynchronousWPFCore.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace AsynchronousWPFCore.ViewModels
{
    public class AsynchronousViewModel : ViewModelBase
    {
        private const int WaitingTime = 3000;
        private Action Example3AsCancelAction;
        
        private bool _isProgressBarRunning = false;
        public bool IsProgressBarRunning
        {
            get => _isProgressBarRunning;
            set
            {
                _isProgressBarRunning = value;
                OnPropertyChanged();
            }
        }

        private string _labelContent = "Press the button";
        public string LabelContent
        {
            get => _labelContent;
            set
            {
                _labelContent = value;
                OnPropertyChanged();
            }
        }

        private ICollectionView _items = new ListCollectionView(new List<int>());
        public ICollectionView Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        

        public ICommand Example1Command { get; set; }
        public ICommand Example2Command { get; set; }
        public ICommand Example1AsCommand { get; set; }
        public ICommand Example2AsCommand { get; set; }
        public ICommand Example3AsCommand { get; set; }
        public ICommand Example3AsCancelCommand { get; set; }
        public ICommand Example4AsCommand { get; set; }
        public ICommand Example5AsCommand { get; set; }
        public ICommand ClearLabelCommand { get; set; }

        public AsynchronousViewModel()
        {
            Example1Command = new RelayCommand(Example_NonAsync);
            Example2Command = new RelayCommand(Example_NonAsync_ThrowingException);
            Example1AsCommand = new RelayCommand(Example_Async);
            Example2AsCommand = new RelayCommand(Example_ThrowingException);
            Example3AsCommand = new RelayCommand(Example_Cancellation);
            Example4AsCommand = new RelayCommand(Example_Deadlock);
            Example5AsCommand = new RelayCommand(Example_ConfigureAwait);

            Example3AsCancelCommand = new RelayCommand(() =>
            {
                Example3AsCancelAction?.Invoke();
            });
            ClearLabelCommand = new RelayCommand(() => LabelContent = "Press the button");
        }


        /////////////////////// Basic synchronous and asynchronous operations ///////////////////////

        private void Example_NonAsync()
        {
            IsProgressBarRunning = true;

            LabelContent = WorkingHttpGetOperation();

            IsProgressBarRunning = false;
        }

        private async void Example_Async()
        {
            IsProgressBarRunning = true;

            LabelContent = await WorkingHttpGetOperationAsync();

            IsProgressBarRunning = false;
        }

        private string WorkingHttpGetOperation()
        {
            Task.Delay(WaitingTime).Wait();
            IOOperation.GetResponse("http://www.onet.pl");
            return "Operation completed";
        }



        private async Task<string> WorkingHttpGetOperationAsync2()
        {
            var taskRes = Task.Factory.StartNew<int>(() => { return 3; });

            Task.Delay(WaitingTime).Wait();
            await IOOperation.GetResponseAsync("http://www.onet.pl");

            var res = await taskRes;
            return "Operation completed";
        }

        private async Task<string> WorkingHttpGetOperationAsync()
        {
            await Task.Delay(WaitingTime);
            var responseResult =  await IOOperation.GetResponseAsync("http://www.onet.pl");
            return "Operation completed";
        }

        //Task<>
        //Task
        //void

        /////////////////////// Faulty synchronous and asynchronous operations ///////////////////////

        private void Example_NonAsync_ThrowingException()
        {
            IsProgressBarRunning = true;

            try
            {
                FailingHttpGetOperation();
                LabelContent = "Operation completed";
            }
            catch (Exception e)
            {
                LabelContent = "Error: " + e.Message;
            }

            IsProgressBarRunning = false;
        }

        private void FailingHttpGetOperation()
        {
            Task task = null;
            try
            {
                task = Task.Factory.StartNew(() => { Thread.Sleep(1000); throw new WebException(); });
                Thread.Sleep(5000);
            }
            catch (WebException wex)
            { 
            }
            catch (AggregateException aex)
            {
                var ex = aex.InnerException;


            }
            catch (Exception ex)
            {
            }


            task?.Wait();
        }


        private void Example_ThrowingException()
        {
            IsProgressBarRunning = true;

            try
            {
                FailingHttpGetOperationAsync();
                LabelContent = "Operation completed";
            }
            catch (Exception e)
            {
                LabelContent = "Error: " + e.Message;
            }

            IsProgressBarRunning = false;
        }

        private async void FailingHttpGetOperationAsync() // async void alert!
        {
            var task = IOOperation.GetResponseAsync("http://www.not-existing-link.abcd");


            bool? status = false;


            try
            {
                await task;
            }
            catch(WebException wex)
            {
                await Console.Out.WriteLineAsync(wex.Message);
            }
            catch (Exception ex)
            {
               // throw; // this is causing application shutdown even when calling method is in try/catch
            }
        }


        /////////////////////// Cancellation of asynchronous operations ///////////////////////

        private async void Example_Cancellation()
        {
            var cancelTokenSrc = new CancellationTokenSource();
            var task = RunOperationAsync(cancelTokenSrc.Token);
            //var task = Task.Run(() => RunOperationAsync(cancelTokenSrc.Token)); // run async task in another thread

            Example3AsCancelAction = () => {
                IsProgressBarRunning = false;
                cancelTokenSrc.Cancel();
            };

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                LabelContent = "Task cancelled";
            }
            catch (Exception e) // not AggregateException
            {
                LabelContent = "Error: " + e.Message;
            }
        }

        private async Task RunOperationAsync(CancellationToken ct)
        {
            IsProgressBarRunning = true;
            for (int i = 0; i < 10; i++)
            {
                //if (!ct.IsCancellationRequested) // when we don't want to throw an exception

                await Task.Delay(WaitingTime, ct);
                //cancellationToken.ThrowIfCancellationRequested(); // not necessary if cancellatonToken was passed into awaited task             
                
                // testing behavior on real exception throwing
                //throw new Exception("test exception");
            }
        }


        /////////////////////// Deadlock in asynchronous operations ///////////////////////

        private void Example_Deadlock()
        {
            IsProgressBarRunning = true;

            var task = RunOperationWithDeadlockAsync();

            task.Wait(6000); // deadlock
           // await task;

            ////no deadlock - thread changed!
            //Task.Run(() =>
            //{
            //    var sc1 = SynchronizationContext.Current;
            //    RunOperationWithDeadlockAsync().Wait();
            //    // returns from Wait on different thread from thread pool, because context is null
            //}).Wait();

        }

        private async Task RunOperationWithDeadlockAsync()
        {
            await Task.Delay(WaitingTime);
            IsProgressBarRunning = false;
        }


        /////////////////////// ConfigureAwait(false) in asynchronous operations ///////////////////////

        private async void Example_ConfigureAwait()
        {
            var sc1 = SynchronizationContext.Current;

            IsProgressBarRunning = true;
            await Method1Async();
            IsProgressBarRunning = false;

            var sc2 = SynchronizationContext.Current;
        }

        private async Task Method1Async()
        {
            var sc1 = SynchronizationContext.Current;
            Items.Refresh(); // operation on UI - needs UI context

            await Method2Async().ConfigureAwait(false);

            var sc2 = SynchronizationContext.Current;
            Items.Refresh(); // operation on UI - needs UI context
        }

        private async Task Method2Async()
        {
            var sc1 = SynchronizationContext.Current;

            await Task.Delay(WaitingTime);

            var sc2 = SynchronizationContext.Current;
            Items.Refresh(); // operation on UI - needs UI context
        }
    }
}

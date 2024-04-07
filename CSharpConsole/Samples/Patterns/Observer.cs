using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.Patterns
{
    internal class ObserverPattern
    {
        private readonly List<INotifier> _listeners;

        public void Attach(INotifier notifier)
        {
            _listeners.Add(notifier);
        }
        public void Detach(INotifier notifier)
        {
            _listeners.Remove(notifier);
        }

        public void TriggerAction()
        {
            foreach (var item in _listeners)
            {
                item.Notify();
            }
        }
    }




    class Observer : INotifier
    {
        public void Notify()
        {
            //throw new NotImplementedException();
        }
    }


    interface INotifier
    {
        void Notify();
    }
}

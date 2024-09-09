using System;

namespace CSharpConsole.Samples.LINQ
{
    class MessageEventArgs : EventArgs
    {
        public string Message{get; set;}

        public MessageEventArgs(string msg)
        {
            Message = msg;
        }
    }

    class EventsPresentation
    {
        public delegate void MessageEventHandler(object obj, MessageEventArgs eventArgs);

        public event MessageEventHandler PreAction;
        public event MessageEventHandler PostAction;

        //public EventsPresentation()
        //{
        //    PreAction += Print;  //you can subscribe to events like this
        //    PreAction += Print;
        //    PostAction += Print;
        //}

        static void Main()
        {
            var ep = new EventsPresentation();
            ep.RunAction();

            Console.ReadKey();
        }

        public void RunAction()
        {
            PreAction?.Invoke(this, new MessageEventArgs("Pre - RunAction"));
            
            //Code executing some action should be here

            PostAction?.Invoke(this, new MessageEventArgs("Post - RunAction"));
        }

        private void Print(object obj, MessageEventArgs eventArgs)
        {
            var message = eventArgs.Message;

            Console.WriteLine(message);
        }
    }
}

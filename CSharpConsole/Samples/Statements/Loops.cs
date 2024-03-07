using System;

namespace CSharpConsole.Samples.Statements
{
    class Loops
    {
        public void ForStatement(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
        }

        public void ForEachStatement(string[] args)
        {
            foreach (string s in args)
            {
                Console.WriteLine(s);
            }
        }

        public void WhileStatement(string[] args)
        {
            int i = 0;
            while (i < args.Length)
            {
                Console.WriteLine(args[i]);
                i++;
            }
        }

        public void DoStatement(string[] args)
        {
            string s;
            do
            {
                s = Console.ReadLine();
                Console.WriteLine(s);
            } while (!string.IsNullOrEmpty(s));
        }

        public void BreakStatement(string[] args)
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                    break;
                Console.WriteLine(s);
            }
        }

        public void ContinueStatement(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("/"))
                    continue;
                Console.WriteLine(args[i]);
            }
        }
    }
}

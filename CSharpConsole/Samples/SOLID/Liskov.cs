using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CSharpConsole.Samples.SOLID
{
    public class Liskov
    {
        List<string> list = new List<string>();
        ISet<string> set = new HashSet<string>();
        LinkedList<string> linkedList = new LinkedList<string>();

        public void Execute()
        {
            var liskov = new Liskov();

            liskov.ModifyCollection(list);
            liskov.CheckState(list);

            liskov.ModifyCollection(set);
            liskov.CheckState(set);

            liskov.ModifyCollection(linkedList);
            liskov.CheckState(linkedList);
        }

        private void ModifyCollection(ICollection<string> collection)
        {
            collection.Add("element");
        }

        private void ModifyCollection<T>(ICollection<T> collection, T elementToAdd)
        {
            collection.Add(elementToAdd);
        }

        private void ModifyCollection(ISet<string> collection)
        {
            collection.Add("element");
        }


        private void PrintCollection(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }


        private void CheckState(ICollection<string> collection)
        {
            var type = collection.GetType().Name;
            Console.WriteLine($"Collection {type} has {collection.Count} element(s).");
        }
    }
}

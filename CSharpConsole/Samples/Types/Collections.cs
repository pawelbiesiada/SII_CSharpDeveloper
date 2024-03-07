using System;
using System.Collections;

namespace CSharpConsole.Samples.Types
{
    public class Collections
    {
        public void ArrayPresentation()
        {
            int[] intArray = new int[10]; //const length initialization, filled with zeros
            string[] strArray = new string[10]; //const length initialization, filled with nulls
            int[] newArray = new[] {1, 2, 3, 4, 5}; //5 length array pre-filled

            Console.WriteLine($"Array {nameof(intArray)} length is {intArray.Length}\ttype: {intArray.GetType().Name}");
            Console.WriteLine($"Array {nameof(strArray)} length is {strArray.Length}\ttype: {strArray.GetType().Name}");
            Console.WriteLine($"Array {nameof(newArray)} length is {newArray.Length}\ttype: {newArray.GetType().Name}");
        }

        public void MultiDimensionArrays()
        {
            //jagged array
            int[][] matrix = new int[2][];
            matrix[0] = new[] {1, 2};
            matrix[1] = new[] {3, 4};

            //int[,] matrix2 = new int[3, 2];
            int[,] matrix2 = {{1,2}, {2,3}, {4,5}};
        }

        public void ListPresentation()
        {
            var list = new ArrayList();
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add("text");
            list.Add(new object());
            list.RemoveAt(2);

            Console.WriteLine($"List count: {list.Count}\tcapacity: {list.Capacity}");
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExercises
{
    internal class TriangleValidator
    {

        public static bool CanTriangleBeConstructed(int a, int b, int c)
        {
            var result = a + b > c
                && a + c > b
                && b + c > a;

            return result;
        }

        public static void CheckAndPrintForTriangleValidation()
        {

            // declare 3 variables
            //string strEdgeA;
            //var strEdgeB;
            //string strEdgeC;

            Console.WriteLine("Please provide three integers, accept each by pressing enter:");
            //read input form console Console.ReadLine()
            var strEdgeA = Console.ReadLine();
            var strEdgeB = Console.ReadLine();
            var strEdgeC = Console.ReadLine();

            // parse string numbers to int int a = int.Parse("5");
            int edgeA = int.Parse(strEdgeA);
            int edgeB = int.Parse(strEdgeB);
            int edgeC = int.Parse(strEdgeC);


            //use if block to check if it's triangle
            if (CanTriangleBeConstructed(edgeA, edgeB, edgeC))

            {
                Console.WriteLine("Triangle can be made.");
            }
            else
            {
                Console.WriteLine("Cannot create triangle.");
            }

            //Console.WriteLine("")
        }
    }
}

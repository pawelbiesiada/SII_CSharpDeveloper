using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExercises
{
    internal class Fibo
    {
        public static int GetNextFibo(int number) //1000
        {
            var i1 = 1;
            var i2 = 1;
            var result = i1 + i2;

            while (result < number)
            {
                i1 = i2;
                i2 = result;

                result = i1 + i2;
            }

            return result;
        }

    }
}

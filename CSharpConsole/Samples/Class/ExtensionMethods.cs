using CSharpConsole.Samples.Class.Inheritance;
using System.Collections;
using System.Collections.Generic;

namespace CSharpConsole.Samples.Class
{
    public static class ExtensionMethods
    {
        public static void WorkHard(this Bulldozer bulldozer)
        {
            while (!bulldozer.IsServiceCheckNeeded())
            {
                bulldozer.DoSomeWork();
            }
        }
        public static string WorkHard(this Bulldozer bulldozer, int times)
        {
            while (!bulldozer.IsServiceCheckNeeded() && times > 0)
            {
                bulldozer.DoSomeWork();
                times--;
            }

            bulldozer.WorkHard(3);
            var isEmail = "aaa@com.pl".IsValidEmailAddress();

            "dsfsfdsf".CountLetter('d');

            return "Work completed";
        }

        public static int MyCustomCount(this IEnumerable collection)
        {
            var sum = 0;
            foreach (var item in collection)
            { sum++; }

            return sum;
        }

        public static bool IsValidEmailAddress(this string email)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }


        public static int CountWords(this string s)
        {
            return s.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int CountLetter(this string s, char letter)
        {
            int sum = 0;

            foreach (var c in s)
            {
                if (c == letter) sum++;
            }
            return sum;

        }

        public static bool LoadElements(this FamilyCar fc, IEnumerable<int> elements)
        {
            foreach (int i in elements)
            {
                try
                {
                    fc.LoadTrunk(i);
                }
                catch (CapacityExceededException e)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

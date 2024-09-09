using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExercises
{
    internal class TextManager
    {


        public static int GetWordCount(string text)
        {
            return text.Split(' ').Length;
        }

        public static string GetTextUntilComma(string text)
        {
            return text.Substring(0, text.IndexOf(','));
        }

        public static string GetTextAfterComma(string text)
        {
            return text.Substring(text.IndexOf(",") + 1);
        }
        public static string GetNWord(string text, int wordNumber)
        {
            return text.Split(' ')[wordNumber-1];
        }

        public static string GetEverySecondWord(string text, int wordNumber)
        {
            string[] strArr = text.Split(' ');
            string s = String.Empty;
            for (int i = 0; i < strArr.Length; i += 2) // i = i + 2
            {
                s += strArr[i];
            }
            return s;
        }

        public static int CountELetter(string text)
        {
            var sum = 0;
            foreach (char ch in text) 
            { 
                if (ch == 'e' || ch == 'E')
                {  
                    sum++; 
                }
            }

            return sum;
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace AdvancedCSharp.Samples.RegEx
{
    class RegExGroups
    {
        static void Main()
        {
            var dateStr = "What happened on 15/01/2002.";
            var datePattern = @"\b(?<day>\d{1,2})/(?<month>\d{1,2})/(?<year>\d{2,4})\b";
            //var datePattern = @"\b\d{1,2}/\d{1,2}/\d{2,4}\b";
            var matchd = Regex.Match(dateStr, datePattern);
            var convertedDate = Regex.Replace(dateStr,
                      datePattern,
                      "${day}-${month}-${year}", RegexOptions.None,
                      TimeSpan.FromMilliseconds(150));

            var year = matchd.Groups["year"].Value;

            Console.WriteLine("Original string: {0}", dateStr);
            Console.WriteLine("Converted string: {0}", convertedDate);
            var matched = Regex.Match(dateStr, datePattern);
            Console.WriteLine("Found groups are: ");
            foreach (Group item in matched.Groups)
            {
                Console.WriteLine("\t{0} = {1}", item.Name, item.Value);
            }
            Console.WriteLine();
            //string pattern = @"\b(\w+)\s\1\b";
            string pattern = @"\b(?<word>\w+)\s\k<word>\b";
            string input = "This this is a nice day. What about this? This tastes good. I saw a a dog.";
            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
            {                
                Console.WriteLine("{0} (duplicates '{1}') at position {2}",
                                  match.Value, match.Groups[1].Value, match.Index);                
                foreach (Group item in match.Groups)
                {
                    Console.WriteLine("\t{0} = {1}", item.Name, item.Value);
                }
            }

            Console.ReadKey();
        }

    }
}

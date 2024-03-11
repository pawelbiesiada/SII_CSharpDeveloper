using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Workshop
{
    internal class Birthday
    {
        public static void DaysPassedSince(DateTime timeInPast)
        {
            var now = DateTime.Now;

            var timeRange = now - timeInPast;

            Console.WriteLine("Od dnia " + now.ToShortDateString() + "minęło " + timeRange.Days + " dni.");
            Console.WriteLine($"Od dnia {now.ToShortDateString()} minęło {timeRange.Hours} godzin.");
        }
    }
}

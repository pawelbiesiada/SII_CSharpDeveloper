using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Workshop
{
    public class RainFall
    {
        private int[] _rainFalls = new int[12];

        public double Average { 
            get 
            {
                var sum = 0;
                foreach (var i in _rainFalls) 
                {
                    sum += i;
                }
                return sum / (_rainFalls.Length * 1.0);
            } 
        }

        public int GetMonthlyRainFall(int month)
        {
            if (month <= 0 || month > 12)
                return 0;

            return _rainFalls[month - 1];
        }

        public int GetMonthlyRainFall(Month month)
        {
            return GetMonthlyRainFall((int)month);
        }

        public void AddRainFall(int month, int fall)
        {
            if (month <= 0 || month > 12)
                throw new ArgumentException(nameof(month));  // "month"
            if(fall < 0)
                throw new ArgumentException("fall");

            _rainFalls[month - 1] += fall;
        }

        public void AddRainFall(Month month, int fall)
        {
            AddRainFall((int)month, fall);
        }

        public void ImportRainFall(RainFall rainFall)
        {
            for (int i = 1; i <= _rainFalls.Length; i++)
            {
                AddRainFall(i, rainFall.GetMonthlyRainFall(i));
            }
        }
        

        private void Test()
        {
            var rainfall = new RainFall();


            rainfall.AddRainFall(Month.March, 40);

            var fallForMarch = rainfall.GetMonthlyRainFall(Month.March);


            // var status = user.GetStatus();
            // user.Status = USerStatus.NoActive;
        }
    }


    enum UserStatus
    {
        Active = 1,
        NoActive = 5,
        Suspended = 2,
        Locked = 2,
        Unregisterd = 8,
    }

    public enum Month
    {
        Styczen = 1,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
    }

}

using System;

namespace CSharpConsole.Samples.Types
{
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public double Distance(Point p)
        {
            return Distance(p.X, p.Y);
        }

        public double Distance(int x, int y)
        {
            return Math.Sqrt(Math.Pow((X - x), 2) + Math.Pow((Y - y), 2));
        }
    }

    public class StructTest
    {
        public static void Main()
        {
            Point myPoint = new Point(1, 1);
            Point anotherPoint = new Point(2, 3);
            Point yetAnotherPoint = new Point(1, 1);

            var distance = myPoint.Distance(anotherPoint);

            //var result = point == point2; //need to overload operator for struct
            var result = myPoint.Equals(anotherPoint); //false
            result = myPoint.Equals(yetAnotherPoint); //true

            myPoint.X = 5;
            result = myPoint.Equals(anotherPoint); //false
            result = myPoint.Equals(yetAnotherPoint); //false

            var copyPoint = myPoint;
            result = myPoint.Equals(copyPoint); //true
            myPoint.X = 10;
            result = myPoint.Equals(copyPoint); //false

            ModifyStruct(myPoint);
            result = myPoint.X == 100; // false

        }

        public static void ModifyStruct(Point point)
        {
            point.X = 100;
        }
    }
}

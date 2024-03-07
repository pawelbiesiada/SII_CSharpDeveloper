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
            Point point = new Point(1, 1);
            Point point2 = new Point(2, 3);
            Point point3 = new Point(1, 1);

            var distance = point.Distance(point2);

            //var areEqual = point == point2; //need to overload operator for struct
            var areEqual = point.Equals(point2); //false
            areEqual = point.Equals(point3); //true

            point.X = 5;
            areEqual = point.Equals(point2); //false
            areEqual = point.Equals(point3); //false

            var copyPoint = point;
            areEqual = point.Equals(copyPoint); //true
            point.X = 10;
            areEqual = point.Equals(copyPoint); //false

            ModifyStruct(point);
            areEqual = point.X == 100; // false

        }

        public static void ModifyStruct(Point point)
        {
            point.X = 100;
        }
    }
}

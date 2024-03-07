using System;

namespace CSharpConsole.Samples.Patterns
{
    internal class Strategy
    {
        static void Main(string[] args)
        {
            var shapeReader = new ShapeReaderStrategy(new EquilateralTriangle());
            Console.WriteLine("Shape is: {0}", shapeReader.GetName());
            shapeReader = new ShapeReaderStrategy(new Circle());
            Console.WriteLine("Shape is: {0}", shapeReader.GetName());
            shapeReader = new ShapeReaderStrategy(new Square());
            Console.WriteLine("Shape is: {0}", shapeReader.GetName());

            Console.ReadKey();
        }
    }

    public interface IShape
    {
        string GetShapeName();
    }
    
    public class ShapeReaderStrategy
    {
        private readonly IShape _shape;
        public ShapeReaderStrategy(IShape shape)
        {
            _shape = shape;
        }

        public string GetName()
        {
            return _shape.GetShapeName();
        }
    }

    public class Square : IShape
    {
        public string GetShapeName()
        {
            return "Square";
        }
    }
    public class Circle : IShape
    {
        public string GetShapeName()
        {
            return "Circle";
        }
    }
    public class EquilateralTriangle : IShape
    {
        public string GetShapeName()
        {
            return "Equilateral triangle";
        }
    }
}

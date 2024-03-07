using System;

namespace CSharpConsole.Samples.Patterns
{
    
    internal class Factory
    {
        private static void Main()
        {
            ICarFactory carFactory = new FordFactory();

            Console.WriteLine("Car created is: {0}", carFactory.GetCar(Model.Fiesta));
            Console.WriteLine("Car created is: {0}", carFactory.GetCar(Model.Focus));
            Console.ReadKey();
        }
    }

    public enum Model
    {
        Mondeo,
        Focus,
        Fiesta
    }

    public interface ICar
    {
        string GetCarName();
    }
    public interface ICarFactory
    {
        ICar GetCar(Model model);
    }

    public class FordFactory : ICarFactory
    {

        public ICar GetCar(Model model)
        {
            switch (model)
            {
                case Model.Mondeo:
                    return new Mondeo();
                    break;
                case Model.Focus:
                    return new Focus();
                    break;
                case Model.Fiesta:
                    return new Fiesta();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(model), model, null);
            } 
        }
    }

    public class Focus : ICar
    {
        public string GetCarName()
        {
            return "Focus";
        }
    }

    public class Fiesta : ICar
    {
        public string GetCarName()
        {
            return "Fiesta";
        }
    }

    public class Mondeo : ICar
    {
        public string GetCarName()
        {
            return "Mondeo";
        }
    }
}

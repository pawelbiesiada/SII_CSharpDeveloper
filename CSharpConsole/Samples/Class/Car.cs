using CSharpConsole.Samples.Class.Inheritance;
using CSharpConsole.Samples.SOLID;
using System;
using System.IO;

namespace CSharpConsole.Samples.Class
{
    struct MyStruct
    {

    }

    class CarDto
    {
        public int Distance { get; set; }
    }

    public class Car : IVehicle, IServiceable
    {
        //Constant Field
        private const int ServiceCheckAfter = 10_000;

        // Fields
        private readonly int _speed;
        private readonly ILogger logger;

        // Constructor
        public Car(int avgSpeed)
        {
            if (avgSpeed < 0)
                throw new ArgumentOutOfRangeException();
            //var car = new Car(100); initialization sample
            _speed = avgSpeed;
        }

        public Car(int avgSpeed, ILogger logger)
        {
            //var car = new Car(100); initialization sample
            _speed = avgSpeed;
            this.logger = logger;
        }

        // Properties
        public int Distance { get; set; }

        public static int StaticDistance {  get; set; }


        // Methods
        public void Drive(int duration)
        {
            Distance += CalculateDistance(_speed, duration);
            StaticDistance += CalculateDistance(_speed, duration);
        }


        public virtual bool IsServiceCheckNeeded()
        {
            var isNeeded = Distance > ServiceCheckAfter;

            if(isNeeded)
            {
                logger?.LogWarning("Need to do a service!!!");
            }
            else
            {
                logger?.LogDebug("Don't need a service.");
            }

            return isNeeded;
        }

        public static int CalculateDistance(int speed, int duration)
        {
            return speed * duration;
        }

        public void DoService()
        {
            throw new NotImplementedException();
        }
    }


    class CarFactory
    {
        public Car CreateCar()
        {
            return new Car(3);
        }
    }

    public class ClassTest
    {
        public static void Main()
        {
            Car car = new Car(30);
            Car car2 = new Car(50);
            Car car3 = new Car(30);

            car.Drive(10);

            Car.CalculateDistance(2,21);
            Console.WriteLine("");

            var areEqual = car == car2; //false
            areEqual = car == car3; //false

            areEqual = car.Equals(car2); //false
            areEqual = car.Equals(car3); //false

            car.Distance = 50;
            areEqual = car.Equals(car2); //false
            areEqual = car.Equals(car3); //false

            var copyCar = car;
            areEqual = car.Equals(copyCar); //true
            car.Distance = 10;
            areEqual = car.Equals(copyCar); //true

            ModifyClass(car);
            areEqual = car.Distance == 100; // true

            ModifyAndInitializeClass(car);
            areEqual = car.Distance == 200; // true
            areEqual = car.Distance == 300; // false
        }

        public static void ModifyClass(Car car)
        {
            car.Distance = 100;
        }

        public static void ModifyAndInitializeClass(Car car)
        {
            car.Distance = 200;
            car = new Car(300);
        }



        public void DoSth(IVehicle c)
        {
            
            var dist = c.Distance;

            c.Drive(100);
        }
    }


    class Motorbike : IVehicle
    {
        public int Distance { get; set; }

        public void Drive(int duration)
        {
        }

        public bool IsServiceCheckNeeded()
        {
            return false;
        }
    }
}

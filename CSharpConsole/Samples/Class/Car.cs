using CSharpConsole.Samples.SOLID;
using System;

namespace CSharpConsole.Samples.Class
{
    public class Car
    {
        //Constant Field
        private const int ServiceCheckAfter = 10_000;

        // Fields
        private readonly int _speed;

        // Constructor
        public Car(int avgSpeed)
        {
            if (avgSpeed < 0)
                throw new ArgumentOutOfRangeException();
            //var car = new Car(100); initialization sample
            _speed = avgSpeed;
        }

        // Properties
        public int Distance { get; set; }


        // Methods
        public void Drive(int duration)
        {
            Distance += CalculateDistance(_speed, duration);
        }

        public bool IsServiceCheckNeeded()
        {
            return Distance > ServiceCheckAfter;
        }

        private static int CalculateDistance(int speed, int duration)
        {
            return speed * duration;
        }
    }

    public class ClassTest
    {
        public static void Main()
        {
            Car myCar = new Car(30);
            Car anotherCar = new Car(50);
            Car yetAnotherCar = new Car(30);

            myCar.Drive(10);

            var result = myCar == anotherCar; //false
            result = myCar == yetAnotherCar; //false

            result = myCar.Equals(anotherCar); //false
            result = myCar.Equals(yetAnotherCar); //false

            myCar.Distance = 50;
            result = myCar.Equals(anotherCar); //false
            result = myCar.Equals(yetAnotherCar); //false

            var copyCar = myCar;
            result = myCar.Equals(copyCar); //true
            myCar.Distance = 10;
            result = myCar.Equals(copyCar); //true

            ModifyClass(myCar);
            result = myCar.Distance == 100; // true

            ModifyAndInitializeClass(myCar);
            result = myCar.Distance == 200; // true
            result = myCar.Distance == 300; // false
        }

        public static void ModifyClass(Car someCar)
        {
            someCar.Distance = 100;
        }

        public static void ModifyAndInitializeClass(Car someCar)
        {
            someCar.Distance = 200;
            someCar = new Car(300);
        }
    }
}

using System;

namespace CSharpConsole.Samples.Class.Inheritance
{
    public class CapacityExceededException : ApplicationException
    {
        public CapacityExceededException() { }

        public CapacityExceededException(string message) : base(message) { }

        public CapacityExceededException(string message, int maxCapacity, int leftCapacity, int load) : this(message)
        {
            MaxCapacity = maxCapacity;
            LeftCapacity = leftCapacity;
            Load = load;
        }

        public int MaxCapacity { get; set; }
        public int LeftCapacity { get; set; }
        public int Load { get; set; }
    }

    public class FamilyCar : Car
    {
        protected int TrunkCapacityLeft;

        public int TrunkCapacity { get; } = 100;

        public FamilyCar(int speed) : base(speed)
        {
            if (speed > 90)
            {
                throw new ArgumentException("Easy, it's just a family car.");
            }

            TrunkCapacityLeft = TrunkCapacity;
        }

        public void LoadTrunk(int load)
        {
            if (load < 0)
            {
                throw new ArgumentException("Load cannot be negative");
            }

            if (load > TrunkCapacityLeft)
            {
                //throw new ApplicationException("The given load exceeds available trunk capacity"); 
                throw new CapacityExceededException("The given load exceeds available trunk capacity")
                { MaxCapacity = TrunkCapacity, LeftCapacity = TrunkCapacityLeft, Load = load };
                //you can create our own exception type here
            }

            //pack the trunk

            //and then reduce its current capacity
            TrunkCapacityLeft -= load;
        }
    }

    class SportCar : Car
    {
        private const int ServiceCheckAfter = 1000; //need to have lower value for SportCar

        private bool WasCarUsedOnSpeedTrack = false;

        public SportCar() : base(200)
        {}

        public SportCar(int speed) : base(speed)
        {
            if (speed < 200)
                throw new ArgumentException($"Speed cannot be lower than 200, actual: {speed}");
        }

        public override bool IsServiceCheckNeeded() //this covers method in Car class
        {
            return WasCarUsedOnSpeedTrack || base.IsServiceCheckNeeded();
        }

        public void DriveFast()
        {
            WasCarUsedOnSpeedTrack = true;
        }
    }

    class LuxurySportCar : SportCar
    {
        public int MyProperty { get; set; }



        public LuxurySportCar() : base(250)
        {

        }

        public LuxurySportCar(int speed) : base(speed)
        {
            if (speed < 250)
                throw new ArgumentException($"Speed cannot be lower than 250, actual: {speed}");
        }
    }

    public sealed class Bulldozer : Car
    {
        public Bulldozer() : base(15){}


        public void DoSomeWork()
        {

        }

        public void WorkHard() { }
    }


    class CarPresentation
    {
        public static void Main()
        {
            var luxury = new LuxurySportCar();
            luxury.Drive(2);
            Car car = new Car(90);

            var obj = new object();

            car = new FamilyCar(80);
            ((FamilyCar)car).LoadTrunk(3);
            FamilyCar fcar = null;

            try
            {
                fcar = new FamilyCar(80);
                fcar.LoadTrunk(1000);
                fcar.LoadElements(new[] { 2, 34, 5, 6 });
            }
            catch (CapacityExceededException e)
            {
                Console.WriteLine("Capacity Exceeded Exception");
                Console.WriteLine("Max capacity: " + e.MaxCapacity);
                Console.WriteLine("Left capacity: " + e.LeftCapacity);
                Console.WriteLine("Load: " + e.Load);                
            }



            car = new SportCar(280);
            car = new LuxurySportCar();
            car = new Bulldozer();


            var sport = new SportCar();

            Car c1 = sport;
            SportCar sc = sport;
            //LuxurySportCar lc = sport;


            DriveCar(sport);
            DriveCar(fcar);
            DriveCar(car);


            var isTypeOf = car is IVehicle;

            Car familyCar = new FamilyCar(80);
            //var capacity = familyCar.TrunkCapacity; // we don't have an access
            var capacity = ((FamilyCar) familyCar).TrunkCapacity;
            ((FamilyCar)familyCar).LoadTrunk(30);

            //var familyCar2 = (SportCar)familyCar;
            //familyCar2.LoadTrunk();

            var isFcar = familyCar is FamilyCar;


            car = new LuxurySportCar();
            
            var isScar = car is SportCar;             //true
            var isLScar = car is LuxurySportCar;      //true

            var newCasted = car as SportCar;




            if (isFcar)
            {

                var familyCar2 = (FamilyCar)familyCar;
            }
            if (isScar)
            {

                var familyCar2 = (SportCar)familyCar;
            }


            var fcar2 = familyCar as FamilyCar;
            var scar2 = familyCar as SportCar;


            scar2?.Drive(3);

            if (scar2 != null)
            {
                scar2.Drive(3);
            }

            SportCar sportCar = new SportCar();
            sportCar = new LuxurySportCar();
            isTypeOf = sportCar is IVehicle;
            //sportCar = new Car(90); // can't do'
            //you can cast detailed object to more generic implicitly

            CastClassTest(sportCar);
            //CastClassTest(car);
            CastClassTest(new LuxurySportCar());
            //CastClassTest(new Bulldozer());

            //CastInterfaceTest(car);
            //CastInterfaceTest(new LuxurySportCar());
            //CastInterfaceTest(new Bulldozer());
        }

        public static void DriveCar(Car car)
        {

            car.Drive(10);
            Console.WriteLine($"new Distance {car.Distance}");
        }

        private static void CastClassTest(SportCar car)
        {

        }

        private static void CastInterfaceTest(IVehicle car)
        {
            car.Drive(10);
            Console.WriteLine($"new Distance {car.Distance}");
        }
    }
}

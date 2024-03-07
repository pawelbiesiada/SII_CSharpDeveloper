namespace CSharpConsole.Samples.Class.Inheritance
{
    public abstract class AbstractPlane
    {
        protected int flyingHours;

        public int Capacity { get; protected set; }
        public int Altitude { get; protected set; }

        protected AbstractPlane()
        {

        }

        protected AbstractPlane(int capacity)
        {

        }
        

        public virtual void TakeOff()
        {
            
            Altitude = 100;
        }
        public virtual void Land()
        {
            Altitude = 0;
        }

        protected abstract void StartEngine();
        protected abstract void StopEngine();
    }

    class Boeing747 : AbstractPlane
    {
        private bool _onOffBoeingSwitch;

        protected override void StartEngine()
        {
            _onOffBoeingSwitch = true;
        }

        protected override void StopEngine()
        {
            _onOffBoeingSwitch = false;
        }
    }


    class AbstractionTest
    {
        public static void Main()
        {
            AbstractPlane plane = new Boeing747(); // OK
            Boeing747 boeing = new Boeing747(); // OK

            //plane = new AbstractPlane(); // can't do
            plane = boeing;
            //boeing = plane; // can't do implicitly
            boeing = (Boeing747)plane; // can do explicitly - but only if we are sure it is it
            boeing = plane as Boeing747;
        }
    }
}

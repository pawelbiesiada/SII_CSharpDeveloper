namespace CSharpConsole.Samples.Class.Inheritance
{
    public interface IVehicle
    {
        int Distance { get; }

        void Drive(int duration);

        bool IsServiceCheckNeeded();
    }
}

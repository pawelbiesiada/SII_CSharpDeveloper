namespace CSharpConsole.Samples.Class.Inheritance
{
    public interface ICar
    {
        int Distance { get; }

        void Drive(int duration);

        bool IsServiceCheckNeeded();
    }
}

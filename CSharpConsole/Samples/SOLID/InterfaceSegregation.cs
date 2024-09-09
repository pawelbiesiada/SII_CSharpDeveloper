namespace CSharpConsole.Samples.SOLID
{
    internal interface IMultifunctionalPrinter
    {
        void Print (byte[] stream);
        byte[] Scan();
    }



    internal interface IScanner
    {
        byte[] Scan();
    }
    internal interface IPrinter
    {
        void Print(byte[] stream);
    }
}
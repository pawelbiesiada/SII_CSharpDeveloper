namespace CSharpConsole.Samples.Class.Inheritance
{
    interface ICalculator
    {
        decimal Add(decimal a, decimal b);
        decimal Subtract(decimal a, decimal b);
        decimal Multiply(decimal a, decimal b);
        decimal Divide(decimal a, decimal b);
    }



    interface ICalc2
    {
        decimal Execute(IOperation operation);
    }

    interface IOperation
    {
        decimal Operation(decimal a, decimal b);
    }

    class Add : IOperation
    {
        public decimal Operation(decimal a, decimal b)
        {
            return a + b;
        }
    }


}

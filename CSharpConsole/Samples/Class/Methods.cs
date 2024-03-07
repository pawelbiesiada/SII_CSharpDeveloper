namespace CSharpConsole.Samples.Class
{
    public class MethodPresentationCalculator
    {
        private int _result;

        public MethodPresentationCalculator()
        {
            _result = 0;
        }

        public MethodPresentationCalculator(int startingPoint)
        {
            //var calc = new MethodPresentationCalculator();
            //calc.Add(2);
            _result = startingPoint;
        }

        public int Add(int value)
        {
            _result += value;
            return _result;
        }

        public int Add(int value1, int value2)
        {
            _result += value1 + value2;
            return _result;
        }

        public int Add(params int[] values)
        {
            foreach (var value in values)
            {
                _result += value;
            }

            return _result;
        }

        public int Add()
        {
            return ++_result;
        }
    }
}

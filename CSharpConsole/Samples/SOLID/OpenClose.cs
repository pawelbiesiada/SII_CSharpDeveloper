using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.SOLID
{
    public class DiscountCalculator
    {
        public double CalculateDiscount(string customerType)
        {
            if (customerType == "Regular") return 0.1;
            if (customerType == "Premium") return 0.2;
            return 0.0;
        }
    }

    public interface IDiscountStrategy
    {
        double GetDiscount();
    }

    public class RegularCustomer : IDiscountStrategy
    {
        public double GetDiscount() => 0.1;
    }

    public class PremiumCustomer : IDiscountStrategy
    {
        public double GetDiscount() => 0.2;
    }

    public class DiscountCalculatorOC
    {
        public double Calculate(IDiscountStrategy strategy) => strategy.GetDiscount();
    }
}

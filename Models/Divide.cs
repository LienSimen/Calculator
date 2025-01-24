using Calc2.Models;

namespace Calc2
{
    public class Division : BaseCalculator
    {

        public override double Execute(double a, double b)
        {
            if(b == 0)
            {
                throw new DivideByZeroException("Cant divide by 0");
            }
            return a / b;
        }

    }
}
using System;

namespace Calc2.Models;

public class Modulo : BaseCalculator
{
    public override double Execute(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cant perform modulo on 0");
        }
        return a % b;
    }
}
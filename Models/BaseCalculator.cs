namespace Calc2.Models;

public abstract class BaseCalculator
{
    // trying abstract here to enforce implementation of the execute method in the derived classes
    public abstract double Execute(double a, double b);
}

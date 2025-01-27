using System;

namespace Calc2.Models;

public static class OperationFactory
{
    // Here we do a switch expression deciding what base calc object we want to make
    public static BaseCalculator GetOperations(string operation)
    {   
        return operation switch
        {
            "+" => new Addition(),
            "-" => new Subtraction(),
            "*" => new Multiplicaiton(),
            "/" => new Division(),
            "%" => new Modulo(),
            _ => throw new ArgumentException("Unsupported  operator"),
        };
    }
}

using Calc2.Models;

namespace Calc2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator started, type Q to exit or total to view total");

            double total = 0;

            while (true)
            {
                Console.WriteLine($"Current Total: {total}");
                Console.WriteLine("Enter a command: (+5, -1, *5, /2, %4, etc) ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid / empty input try again.");
                    continue;
                }

                // Exit condition
                if (input.ToLower() == "q")
                {
                    Console.WriteLine("Exiting Calculator. Final Total: " + total);
                    break;
                }

                // Show total
                if (input.ToLower() == "total")
                {
                    Console.WriteLine($"Current Total: {total}");
                    continue;
                }

                // Split the operation and number
                char operation = input[0];
                string numberPart = input.Substring(1).Trim();

                if (!"+-*/%".Contains(operation) || !double.TryParse(numberPart, out double number))
                {
                    Console.WriteLine("Error wrong input, try +1, -5, /4, *2");
                    continue;
                }
                // Flexible variable of type BaseCalculator so it can hold any object from subclasses(Add, subtract etc)
                BaseCalculator operationInstance;
                // Select operation
                try
                {
                    // Determine which operation to execute based on stored operation(+,-,/,%,*) that we extracted above
                    // Creating the correct instance (add, minus, multiply, divide, etc).
                    // Achieved = Polymorphism (we use same named method "Execute" on all operations)
                    // Not achieved = Method overloading. We didnt overload the execute method itself with different parameters.
                    operationInstance = OperationFactory.GetOperations(operation.ToString());
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine(error.Message);
                    continue;
                }
            
                try
                {
                    // And here we execute the selected operation
                    total = operationInstance.Execute(total, number);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero. Try again.");
                }
            }
        }
    }
}

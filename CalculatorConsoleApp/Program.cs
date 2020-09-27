using System;
using System.Diagnostics.CodeAnalysis;

namespace CalculatorConsoleApp
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main()
        {
            Calculator calculator = new Calculator();
            string str = Console.ReadLine();
            Console.WriteLine(calculator.Calc(str));
        }
    }
}
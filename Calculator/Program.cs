using System;
using System.Diagnostics.CodeAnalysis;
namespace Calculator
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                var calculator = new Calculator();
                var str = Console.ReadLine();
                var value = calculator.Calc(str);
                Console.WriteLine(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

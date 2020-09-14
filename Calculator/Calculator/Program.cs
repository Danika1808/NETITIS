using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine().Split();
            var arg1 = CalculatorUtils.GetNumber(s[0]);
            var arg2 = CalculatorUtils.GetNumber(s[2]);
            Console.WriteLine(CalculatorUtils.Calc(arg1, arg2, s[1]));
        }
    }
}

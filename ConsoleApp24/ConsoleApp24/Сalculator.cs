using System;
using System.Diagnostics.Eventing.Reader;


namespace ConsoleApp24
{
    public static class Сalculator
    {
        public static double Calc(double arg1, double arg2, string oper)
        {
            switch (oper)
            {
                case "+": return arg1 + arg2;
                case "-": return arg1 - arg2;
                case "*": return arg1 * arg2;
                case "/": return arg1 / arg2;
                default:
                    throw new ArgumentException($"Неверная операция {oper}");
            }
        }
        public static double GetNumber(string str)
        {
            if (double.TryParse(str, out _))
                return double.Parse(str);
            else
                throw new ArgumentException($"Неверное значение");
        }
    }
}

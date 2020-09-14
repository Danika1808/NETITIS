using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp24
{
    public class Calculator
    {
        public static decimal Calc(decimal arg1, decimal arg2, string oper)
        {
            switch (oper)
            {
                case "+": return arg1 + arg2;
                case "-": return arg1 - arg2;
                case "*": return arg1 * arg2;
                case "/":
                    try
                    {
                        return arg1 / arg2;
                    }
                    catch (DivideByZeroException e)
                    {
                        throw new Exception(e.Message);
                    }
                default:
                    throw new ArgumentException($"Неверная операция {oper}");
            }
        }
        public static decimal GetNumber(string str)
        {
            try
            {
                return decimal.Parse(str);
            }
            catch (FormatException e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}

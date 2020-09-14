﻿using System;


namespace ConsoleApp24
{
    public static class Сalculator
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
                        Console.WriteLine(e.Message);
                        throw;
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
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

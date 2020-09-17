using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Сalculator
    {
        public static void Calc(decimal arg1, decimal arg2, string @oper, out decimal result)
        {
            var temp = @oper switch
            {
                "+" => arg1 + arg2,
                "-" => arg1 - arg2,
                "*" => arg1 * arg2,
                "/" => arg1 / arg2,
                _ => throw new NotSupportedException()
            };
            result = temp;
        }
        public static decimal GetNumber(string s)
        {
            try
            {
                return decimal.Parse(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static decimal Input(string s)
        {
            string[] str = s.Split();
            var arg1 = GetNumber(str[0]);
            var arg2 = GetNumber(str[2]);
            Calc(arg1, arg2, str[1], out decimal result);
            return result;
        }
    }
}
using System;

namespace ConsoleApp1
{
    public static class Calculator
    {
        public static decimal Calc(decimal arg1, decimal arg2, string @oper)
        {
            var result = @oper switch
            {
                "+" => arg1 + arg2,
                "-" => arg1 - arg2,
                "*" => arg1 * arg2,
                "/" => arg1 / arg2,
                _ => throw new NotSupportedException()
            };
            return result;
        }
        public static decimal GetNumber(string s)
        {
            return decimal.Parse(s);
        }

        public static string[] Split(string s)
        {
            return s.Split();
        }
        public static decimal OutPut(string s)
        {
            var str = Split(s);
            var arg1 = GetNumber(str[0]);
            var arg2 = GetNumber(str[2]);
            return Calc(arg1, arg2, str[1]);
        }
    }
}
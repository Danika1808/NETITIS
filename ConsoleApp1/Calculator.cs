using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ConsoleApp1
{
    public static class Calculator
    {
        private static Dictionary<string, Func<decimal, decimal, decimal>> CalcOper =
            new Dictionary<string, Func<decimal, decimal, decimal>>()
            {
                {"+", (a, b) => a + b },
                {"-", (a, b) => a - b },
                {"*", (a, b) => a * b },
                {"/", (a, b) => a / b }
            };
        public static decimal Calc(decimal arg1, decimal arg2, string oper)
        {
            try
            {
                return CalcOper[oper](arg1, arg2);
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
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
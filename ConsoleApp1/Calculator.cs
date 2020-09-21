using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
            return CalcOper[oper](arg1, arg2);
        }
        public static decimal GetNumber(string s)
        {
            NumberStyles styles = NumberStyles.AllowDecimalPoint;
            CultureInfo provider = new CultureInfo("en-US");
            return Decimal.Parse(s, styles, provider);
        }
        public static decimal OutPut(string s)
        {
            var str = s.Split();
            var arg1 = GetNumber(str[0]);
            var arg2 = GetNumber(str[2]);
            return Calc(arg1, arg2, str[1]);
        }
    }
}
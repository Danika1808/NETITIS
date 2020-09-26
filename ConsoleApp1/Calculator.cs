using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Text;

namespace ConsoleApp1
{
    public class Calculator
    {
        private readonly Dictionary<string, Func<decimal, decimal, decimal>> CalculatorOperations =
            new Dictionary<string, Func<decimal, decimal, decimal>>()
            {
                {"+", (a, b) => a + b },
                {"-", (a, b) => a - b },
                {"*", (a, b) => a * b },
                {"/", (a, b) => a / b }
            };
        public decimal Calc(decimal arg1, decimal arg2, string oper)
        {
            return CalculatorOperations[oper](arg1, arg2);
        }
        public decimal GetNumber(string s)
        {
            NumberStyles styles = NumberStyles.AllowDecimalPoint;
            CultureInfo provider = new CultureInfo("en-US");
            return Decimal.Parse(s, styles, provider);
        }
        public decimal Calc(string s)
        {
            var str = s.Split();
            var arg1 = GetNumber(str[0]);
            var arg2 = GetNumber(str[2]);
            return Calc(arg1, arg2, str[1]);
        }
    }
}
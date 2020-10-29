using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    class Calc
    {
        static async public Task<decimal> Calculate(Expression input)
        {
            var result = await BinaryVisitor.VisitAsync(input);
            return result;
        }
        public static decimal GetNumber(string s)
        {
            const NumberStyles styles = NumberStyles.AllowDecimalPoint;
            var provider = new CultureInfo("en-US");
            return decimal.Parse(s, styles, provider);
        }
    }
}

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
        public static async Task<decimal> Calculate(Expression input)
        {
            var result = await BinaryVisitor.VisitAsync(input);
            return result;
        }
    }
}

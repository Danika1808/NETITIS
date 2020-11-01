using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExpressionTree
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var n = "5+(7-2,2*3)*(6-4)/2";
            var tree = ParseToTree.ParsingExpression(n);
            BinaryVisitor binaryVisitor = new BinaryVisitor((BinaryExpression)tree);
            binaryVisitor.VisitAndWrite();
            Console.WriteLine(await Calc.Calculate(tree));
        }
    }
}

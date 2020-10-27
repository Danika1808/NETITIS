using System;
using System.Linq.Expressions;

namespace ExpressionTree
{
    class Program
    {
        static void Main()
        {
            var n = "12/(3+2)*7+8*9";
            ParseToTree parseToTree = new ParseToTree();
            var result = parseToTree.Parse(n);
            Console.WriteLine(result);
        }
    }
}

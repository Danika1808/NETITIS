using System;
using System.Linq.Expressions;

namespace ExpressionTree
{
    class Program
    {
        static void Main()
        {
            var n = "6/12*7+8*9";
            ParseToTree parseToTree = new ParseToTree();
            parseToTree.Parse(n);
        }
    }
}

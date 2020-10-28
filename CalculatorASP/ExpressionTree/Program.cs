using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExpressionTree
{
    class Program
    {
        static async Task Main()
        {
            var n = "12.1/(3.2+2)*7.96+8.14*9.5";
            Expression result = ParseToTree.Parse(n);
            Calc calc = new Calc();
            Console.WriteLine(await calc.Calculate(result));

        }
    }
}

using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ExpressionTree
{
    internal class BinaryVisitor : Visitor
    {
        private readonly BinaryExpression node;
        public BinaryVisitor(BinaryExpression node) : base(node)
        {
            this.node = node;
        }
        public override void VisitAndWrite()
        {
            Console.WriteLine($"This binary expression is a {node} expression");
            Console.WriteLine($"The Left argument is: {node.Left}");
            var left = Visitor.CreateFromExpression(node.Left);
            if (left != null)
                left.VisitAndWrite();
            Console.WriteLine($"The Right argument is: {node.Right}");
            var right = Visitor.CreateFromExpression(node.Right);
            if (right != null)
                right.VisitAndWrite();
        }
        public static async Task<decimal> VisitAsync(Expression node)
        {
            if (node.NodeType == ExpressionType.Constant)
            {
                var tmp = node as ConstantExpression;
                return (decimal)tmp.Value;
            }
            else
            {
                string operation;
                switch (node.NodeType)
                {
                    case ExpressionType.Add:
                        {
                            operation = "+";
                            break;
                        }
                    case ExpressionType.Subtract:
                        {
                            operation = "-";
                            break;
                        }
                    case ExpressionType.Multiply:
                        {
                            operation = "*";
                            break;
                        }
                    case ExpressionType.Divide:
                        {
                            operation = "/";
                            break;
                        }
                    default:
                        {
                            throw new Exception();
                        }
                }
                var binaryNode = node as BinaryExpression;
                var left = Task.Run(() => VisitAsync(binaryNode.Left));
                var right = Task.Run(() => VisitAsync(binaryNode.Right));
                var tasks = await Task.WhenAll(new[] { left, right });
                await Task.Yield();
                var result = Responce.GetPesponsing(tasks[0], tasks[1], operation);
                return Calc.GetNumber(result);
            }

        }
    }
}
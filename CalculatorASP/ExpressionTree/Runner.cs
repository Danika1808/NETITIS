using System;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace ExpressionTree
{
    public class Runner
    {
        private static ServiceProvider _serviceProvider;

        public Runner(ServiceCollection serviceProvider)
        {
            _serviceProvider = serviceProvider.BuildServiceProvider();
        }

        public async void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == null)
                    break;
                var expressionParse = _serviceProvider.GetService<IParseToTree>();
                var tree = expressionParse.ParsingExpression(input);
                Console.WriteLine($"Ответ {tree}");
            }
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
                            operation = "%2B";
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
                            operation = "%2F";
                            break;
                        }
                    default:
                        {
                            throw new Exception();
                        }
                }
                var binaryNode = node as BinaryExpression;
                Console.WriteLine($"The Left argument is: {binaryNode.Left}");
                var left = Task.Run(() => VisitAsync(binaryNode.Left));
                Console.WriteLine($"The Left argument is: {binaryNode.Right}");
                var right = Task.Run(() => VisitAsync(binaryNode.Right));
                var tasks = await Task.WhenAll(new[] { left, right });
                await Task.Yield();
                var expression = tasks[0] + "+" + operation + "+" + tasks[1];
                expression = expression.Replace(',', '.');
                HttpClient client = new HttpClient();
                var responce = await client.GetAsync("http://localhost:51963?value=" + expression);
                var content = await responce.Content.ReadAsStringAsync();
                return decimal.Parse(content);
            }

        }

    }
}
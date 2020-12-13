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

        public void Run()
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
                dynamic operation = node.NodeType switch
                {
                    ExpressionType.Add => "%2B",
                    ExpressionType.Subtract => "-",
                    ExpressionType.Multiply => "*",
                    ExpressionType.Divide => "%2F",
                    _ => throw new Exception()
                };
                var binaryNode = node as BinaryExpression;
                Task<decimal> left = null;
                Task<decimal> right = null;
                var task = Task.Run(() =>
                {
                    left = Task.Run(() => VisitAsync(binaryNode.Left));
                    right = Task.Run(() => VisitAsync(binaryNode.Right));
                });
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
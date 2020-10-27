using System;
using System.Linq.Expressions;

namespace ExpressionTree
{
    public class ParseToTree
    {
        public Expression Parse(string input)
        {
            //Заметили плюс
            if (input.LastIndexOf('+') != -1 && (input.LastIndexOf('+') < input.LastIndexOf('(') || input.LastIndexOf('+') > input.LastIndexOf(')')))
            {
                return Expression.MakeBinary
                    (
                    ExpressionType.Add,
                    Parse(input.Substring(0, input.LastIndexOf('+'))),
                    Parse(input.Substring(input.LastIndexOf('+') + 1))
                    );
            }
            //Заметили минус
            else if (input.LastIndexOf('-') != -1 && (input.LastIndexOf('-') < input.LastIndexOf('(') || input.LastIndexOf('-') > input.LastIndexOf(')')))
            {
                return Expression.MakeBinary
                    (
                    ExpressionType.Subtract,
                    Parse(input.Substring(0, input.LastIndexOf('-'))),
                    Parse(input.Substring(input.LastIndexOf('-') + 1))
                    );
            }
            //Заметили делить
            else if (input.IndexOf('/') != -1)
            {
                //Делить перед открывающийся скобкой
                if (Math.Abs(input.IndexOf('/') - input.IndexOf('(')) == 1)
                {
                    return Expression.MakeBinary
                        (
                        ExpressionType.Divide,
                        Parse(input.Substring(0, input.LastIndexOf('/'))),
                        Parse(input.Substring(input.LastIndexOf('('), input.LastIndexOf(')')))
                        );
                }
                //Делить после закрывающийся скобки
                else if (Math.Abs(input.IndexOf('/') - input.IndexOf(')')) == 1)
                {
                    return Expression.MakeBinary
                        (
                        ExpressionType.Divide,
                        Parse(input.Substring(input.LastIndexOf('(') + 1, input.LastIndexOf(')') - 1)),
                        Parse(input.Substring(input.LastIndexOf('/') + 1))
                        );
                }
                //Делить сам по себе
                else
                {
                    return Expression.MakeBinary
                        (
                        ExpressionType.Divide,
                        Parse(input.Substring(0, input.LastIndexOf('/'))),
                        Parse(input.Substring(input.LastIndexOf('/') + 1))
                        );
                }
            }
            //Заметили умножить
            else if (input.IndexOf('*') != -1)
            {
                //Умножить перед открывающийся скобкой
                if (Math.Abs(input.IndexOf('*') - input.IndexOf('(')) == 1)
                {
                    return Expression.MakeBinary
                        (
                        ExpressionType.Multiply,
                        Parse(input.Substring(0, input.LastIndexOf('*'))),
                        Parse(input.Substring(input.LastIndexOf('('), input.LastIndexOf(')')))
                        );
                }
                //Делить после закрывающийся скобки
                else if (Math.Abs(input.IndexOf('*') - input.IndexOf(')')) == 1)
                {
                    return Expression.MakeBinary
                        (
                        ExpressionType.Multiply,
                        Parse(input.Substring(input.LastIndexOf('(') + 1, input.LastIndexOf(')') - 1)),
                        Parse(input.Substring(input.LastIndexOf('*') + 1)));
                }
                //Делить сам по себе
                else
                {
                    return Expression.MakeBinary
                        (
                        ExpressionType.Multiply,
                        Parse(input.Substring(0, input.LastIndexOf('*'))), 
                        Parse(input.Substring(input.LastIndexOf('*') + 1))
                        );
                }
            }
            else
                return Expression.Constant(int.Parse(input));
        }
    }
}


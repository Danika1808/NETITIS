using System;
using System.Linq.Expressions;

namespace ExpressionTree
{
    public class ParseToTree
    {
        public Expression Parse(string input)
        {
            if (input.LastIndexOf('+') != -1 && (input.LastIndexOf('+') < input.LastIndexOf('(') || input.LastIndexOf('+') > input.LastIndexOf(')')))
            {
                return Expression.MakeBinary(ExpressionType.Add, Parse(input.Substring(0, input.LastIndexOf('+'))), Parse(input.Substring(input.LastIndexOf('+') + 1)), false, typeof(Responce).GetMethod("GetPesponsing"));   
            }
            else if (input.LastIndexOf('-') != -1 && (input.LastIndexOf('-') < input.LastIndexOf('(') || input.LastIndexOf('-') > input.LastIndexOf(')')))
            {
                return Expression.MakeBinary(ExpressionType.Subtract, Parse(input.Substring(0, input.LastIndexOf('-'))), Parse(input.Substring(input.LastIndexOf('-') + 1)), false, typeof(Responce).GetMethod("GetPesponsing"));
            }
            else if (input.IndexOf('/') != -1)
            {
                if (Math.Abs(input.IndexOf('/') - input.IndexOf('(')) == 1)
                    return Expression.MakeBinary(ExpressionType.Divide, Parse(input.Substring(0, input.LastIndexOf('/'))), Parse(input.Substring(input.LastIndexOf('('), input.LastIndexOf(')'))), false, typeof(Responce).GetMethod("GetPesponsing"));
                else if (Math.Abs(input.IndexOf('/') - input.IndexOf(')')) == 1)
                    return Expression.MakeBinary(ExpressionType.Divide, Parse(input.Substring(input.LastIndexOf('(') + 1, input.LastIndexOf(')') - 1)), Parse(input.Substring(input.LastIndexOf('/') + 1)), false, typeof(Responce).GetMethod("GetPesponsing"));

                else return Expression.MakeBinary(ExpressionType.Divide, Parse(input.Substring(0, input.LastIndexOf('/'))), Parse(input.Substring(input.LastIndexOf('/') + 1)), false, typeof(Responce).GetMethod("GetPesponsing"));
            }
            else if (input.IndexOf('*') != -1)
            {
                if (Math.Abs(input.IndexOf('*') - input.IndexOf('(')) == 1)
                    return Expression.MakeBinary(ExpressionType.Multiply, Parse(input.Substring(0, input.LastIndexOf('*'))), Parse(input.Substring(input.LastIndexOf('('), input.LastIndexOf(')'))), false, typeof(Responce).GetMethod("GetPesponsing"));
                else if (Math.Abs(input.IndexOf('*') - input.IndexOf(')')) == 1)
                    return Expression.MakeBinary(ExpressionType.Multiply, Parse(input.Substring(input.LastIndexOf('(') + 1, input.LastIndexOf(')') - 1)), Parse(input.Substring(input.LastIndexOf('*') + 1)), false, typeof(Responce).GetMethod("GetPesponsing"));

                else return Expression.MakeBinary(ExpressionType.Multiply, Parse(input.Substring(0, input.LastIndexOf('*'))), Parse(input.Substring(input.LastIndexOf('*') + 1)), false, typeof(Responce).GetMethod("GetPesponsing"));
            }
            else
                return Expression.Constant(int.Parse(input));
        }
    }
}


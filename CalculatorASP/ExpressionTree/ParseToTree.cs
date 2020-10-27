using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionTree
{
    public class ParseToTree
    {
        public static Stack<Expression> expList = new Stack<Expression>();
        public Expression Parse(string input)
        {
            if (input.LastIndexOf('+') != -1)
            {
                return Expression.MakeBinary(ExpressionType.Add, Parse(input.Substring(0, input.LastIndexOf('+'))), Parse(input.Substring(input.LastIndexOf('+') + 1)), false, typeof(Responce).GetMethod("GetResponsiPlus"));
            }
            else if (input.LastIndexOf('-') != -1)
            {
                return Expression.MakeBinary(ExpressionType.Subtract, Parse(input.Substring(0, input.LastIndexOf('-'))), Parse(input.Substring(input.LastIndexOf('-') + 1)), false, typeof(Responce).GetMethod("GetResponsiPlus"));
            }
            else if (input.IndexOf('/') != -1)
            {
                return Expression.MakeBinary(ExpressionType.Divide, Parse(input.Substring(0, input.LastIndexOf('/'))), Parse(input.Substring(input.LastIndexOf('/') + 1)), false, typeof(Responce).GetMethod("GetResponsiPlus"));
            }
            else if (input.IndexOf('*') != -1)
            {
                return Expression.MakeBinary(ExpressionType.Multiply, Parse(input.Substring(0, input.LastIndexOf('*'))), Parse(input.Substring(input.LastIndexOf('*') + 1)), false, typeof(Responce).GetMethod("GetResponsiPlus"));
            }
            else
                return Expression.Constant(int.Parse(input));
        }
        public void GetExpression()
        {

        }
        static int GetPriority(char action)
        {
            switch (action)
            {
                case '*':
                case '/': return 2;
                case '+':
                case '-': return 1;
            }
            return 0;
        }
        static bool SearchOper(string input)
        {
            return input.IndexOf('+') == -1 ||
                input.IndexOf('-') == -1 ||
                input.IndexOf('/') == -1 ||
                input.IndexOf('*') == -1;

        }
    }
}


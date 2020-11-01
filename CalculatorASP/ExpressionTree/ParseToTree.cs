using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTree
{
    public class ParseToTree : IParseToTree
    {
        public static Stack<Expression> expList = new Stack<Expression>();//Constant
        public static Stack<ConstantExpression> opExpList = new Stack<ConstantExpression>();//MakeTree
        public Expression ParsingExpression(string exp)
        {
            opExpList.Push(Expression.Constant('('));
            int pos = 0;
            while (pos <= exp.Length)
            {
                if (pos == exp.Length || exp[pos] == ')')
                {
                    ProcessClosingParenthesis();
                    pos++;
                }
                else if (exp[pos] >= '0' && exp[pos] <= '9')
                {
                    pos = ProcessInputNumber(exp, pos);
                }
                else
                {
                    ProcessInputOperator(exp[pos]);
                    pos++;
                }
            }
            return expList.Pop();
        }

        private static void ProcessClosingParenthesis()
        {
            while (Convert.ToChar(opExpList.Peek().Value) != '(')
                ExecuteOperation();
            opExpList.Pop(); // Remove the opening parenthesis
        }

        private static int ProcessInputNumber(string exp, int pos)
        {

            string value = string.Empty;
            while (pos < exp.Length && ((exp[pos] >= '0' && exp[pos] <= '9') || exp[pos] ==','))
                value += exp[pos++];
            expList.Push(Expression.Constant(decimal.Parse(value)));

            return pos;

        }

        private static void ProcessInputOperator(char op)
        {
            while (opExpList.Count > 0 &&
                    OperatorCausesEvaluation(op, Convert.ToChar(opExpList.Peek().Value)))
                ExecuteOperation();

            opExpList.Push(Expression.Constant(op));

        }

        private static bool OperatorCausesEvaluation(char op, char prevOp)
        {
            bool evaluate = false;
            switch (op)
            {
                case '+':
                case '-':
                    evaluate = (prevOp != '(');
                    break;
                case '*':
                case '/':
                    evaluate = (prevOp == '*' || prevOp == '/');
                    break;
                case ')':
                    evaluate = true;
                    break;
            }
            return evaluate;
        }

        //Создаётся дерево
        private static void ExecuteOperation()
        {
            Expression rightOperand;
            Expression leftOperand;
            try
            {
                rightOperand = expList.Pop();
                leftOperand = expList.Pop();
            }
            catch
            {
                throw new Exception("Строка имеет не верный формат");
            }
            ConstantExpression op = opExpList.Pop();
            BinaryExpression result = op.Value switch
            {
                '+' => Expression.MakeBinary(ExpressionType.Add, leftOperand, rightOperand),
                '-' => Expression.MakeBinary(ExpressionType.Subtract, leftOperand, rightOperand),
                '*' => Expression.MakeBinary(ExpressionType.Multiply, leftOperand, rightOperand),
                '/' => Expression.MakeBinary(ExpressionType.Divide, leftOperand, rightOperand),
                _ => throw new ArgumentException(),
            };
            expList.Push(result);
        }
    }
}

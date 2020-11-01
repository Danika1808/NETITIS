using System.Linq.Expressions;

namespace ExpressionTree
{
    public interface IParseToTree
    {
        public Expression ParsingExpression(string exp);
    }
}
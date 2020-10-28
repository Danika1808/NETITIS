using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ExpressionTree
{
    public abstract class Visitor
    {
        private readonly Expression node;

        protected Visitor(Expression node)
        {
            this.node = node;
        }

        public abstract void VisitAndWrite();
        public ExpressionType NodeType => this.node.NodeType;
        public static Visitor CreateFromExpression(Expression node)
        {
            return node.NodeType switch
            {
                ExpressionType.Add => new BinaryVisitor((BinaryExpression)node),
                ExpressionType.Subtract => new BinaryVisitor((BinaryExpression)node),
                ExpressionType.Divide => new BinaryVisitor((BinaryExpression)node),
                ExpressionType.Multiply => new BinaryVisitor((BinaryExpression)node),
                _ => default,
            };
        }
    }
}

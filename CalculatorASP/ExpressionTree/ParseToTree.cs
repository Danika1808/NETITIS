using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace ExpressionTree
{
    public class Cell
    {
        public double Value { get; set; }
        public char Action { get; set; }
        public Cell(double value, char action)
        {
            Value = value;
            Action = action;
        }
        static int GetPriority(char action)
        {
            switch (action)
            {
                case '^': return 4;
                case '*':
                case '/': return 3;
                case '+':
                case '-': return 2;
            }
            return 0;
        }
        static bool CanMergeCells(Cell leftCell, Cell rightCell)
        {
            return GetPriority(leftCell.Action) >= GetPriority(rightCell.Action);
        }

    }
}

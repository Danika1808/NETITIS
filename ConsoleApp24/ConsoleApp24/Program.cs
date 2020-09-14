using System;

namespace ConsoleApp24
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine().Split();
            var arg1 = Calculator.GetNumber(s[0]);
            var arg2 = Calculator.GetNumber(s[2]);
            Console.WriteLine(Calculator.Calc(arg1, arg2, s[1]));
        }
    }
}

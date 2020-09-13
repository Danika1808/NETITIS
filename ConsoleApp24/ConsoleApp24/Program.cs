using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp24
{
    class Program
    {
        static void Main()
        {
            var s = Console.ReadLine().Split();
            double arg1 = Сalculator.GetNumber(s[0]);
            double arg2 = Сalculator.GetNumber(s[2]);
            Console.WriteLine(Сalculator.Calc(arg1, arg2, s[1]));
        }
    }
}

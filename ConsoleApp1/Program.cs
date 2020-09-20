using System;
using System.Diagnostics.CodeAnalysis;
namespace ConsoleApp1
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine(Calculator.OutPut(Console.ReadLine()));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject1
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UnitTest1
    { /// <summary>
        /// Тест сложения калькулятора
        /// </summary>
        [TestMethod]
        public void Plus()
        {
            decimal a = 2;
            decimal b = 2.4m;
            string oper = "+";
            decimal expected = 4.4m;
            decimal result = Calculator.Calc(a, b, oper);
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Тест вычитания калькулятора
        /// </summary>
        [TestMethod]
        public void Minus()
        {
            decimal a = 17.4m;
            decimal b = 5.5m;
            string oper = "-";
            decimal expected = 11.9m;
            decimal result = Calculator.Calc(a, b, oper);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Тест деления калькулятора
        /// </summary>
        [TestMethod]
        public void Devide()
        {
            decimal a = 20;
            decimal b = 5.5m;
            string oper = "/";
            decimal expected = 3.6363636363636363636363636364m;
            decimal result = Calculator.Calc(a, b, oper);
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Тест умножения калькулятора
        /// </summary>
        [TestMethod]
        public void Multiply()
        {
            decimal a = 6.3m;
            decimal b = 6.3m;
            string oper = "*";
            decimal expected = 39.69m;
            decimal result = Calculator.Calc(a, b, oper);
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Тест получения числа
        /// </summary>
        [TestMethod]
        public void GetNumber()
        {
            string input = "4.4";
            decimal expected = 4.4m;
            decimal result = Calculator.GetNumber(input);
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Тест возвращения результата
        /// </summary>
        [TestMethod]
        public void OutPut()
        {
            string input = "4.8 + 2.8";
            decimal result = Calculator.OutPut(input);
            decimal expected = 7.6m;
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Тест исключения деление на нуль
        /// </summary>
        [TestMethod]
        public void ExpDevide() => Assert.ThrowsException<DivideByZeroException>(() => Calculator.Calc(2.0m, 0.0m, "/"));
        /// <summary>
        /// Тест исключения неизвестная операция
        /// </summary>
        [TestMethod]
        public void ExpOper() => Assert.ThrowsException<KeyNotFoundException>(() => Calculator.Calc(2.0m, 2.0m, "f"));
    }
}

using CalculatorConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UnitTestCalculatorConsoleApp
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UnitTest
    {
        /// <summary>
        /// Тест сложения калькулятора
        /// </summary>
        [TestMethod]
        public void Plus_2plus2dot4_4dot4Returned()
        {
            Calculator calculator = new Calculator();
            decimal a = 2;
            decimal b = 2.4m;
            string oper = "+";
            decimal expected = 4.4m;
            decimal result = calculator.Calc(a, b, oper);
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Тест вычитания калькулятора
        /// </summary>
        [TestMethod]
        public void Minus_17dot4minus5dot5_11dot9Returned()
        {
            Calculator calculator = new Calculator();
            decimal a = 17.4m;
            decimal b = 5.5m;
            string oper = "-";
            decimal expected = 11.9m;
            decimal result = calculator.Calc(a, b, oper);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Тест деления калькулятора
        /// </summary>
        [TestMethod]
        public void Devide_20devide5dot5_3dot6363Returned()
        {
            Calculator calculator = new Calculator();
            decimal a = 20;
            decimal b = 5.5m;
            string oper = "/";
            double delta = 0.0001;
            double expected = 3.6363;
            decimal result = calculator.Calc(a, b, oper);
            double actual = (double)result;
            Assert.AreEqual(expected, actual, delta);
        }
        /// <summary>
        /// Тест умножения калькулятора
        /// </summary>
        [TestMethod]
        public void Multiply_6dot3multiply6dot3_39dot69Returned()
        {
            Calculator calculator = new Calculator();
            decimal a = 6.3m;
            decimal b = 6.3m;
            string oper = "*";
            decimal expected = 39.69m;
            decimal result = calculator.Calc(a, b, oper);
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Тест получения числа
        /// </summary>
        [TestMethod]
        public void GetNumber()
        {
            Calculator calculator = new Calculator();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string input = "4.4";
            decimal expected = 4.4m;
            decimal result = calculator.GetNumber(input);
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Тест возвращения результата
        /// </summary>
        [TestMethod]
        public void OutPut()
        {
            Calculator calculator = new Calculator();
            string input = "4.8 + 2.8";
            decimal result = calculator.Calc(input);
            decimal expected = 7.6m;
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Тест исключения деление на нуль
        /// </summary>
        [TestMethod]
        public void DivideByZeroException()
        {
            Calculator calculator = new Calculator();
            decimal a = 20;
            decimal b = 0;
            string oper = "/";
            Assert.ThrowsException<DivideByZeroException>(() => calculator.Calc(a, b, oper));
        }

        /// Тест исключения неизвестная операция
        /// </summary>
        [TestMethod]
        public void KeyNotFoundException()
        {
            Calculator calculator = new Calculator();
            decimal a = 18;
            decimal b = 21;
            string oper = "f";
            Assert.ThrowsException<KeyNotFoundException>(() => calculator.Calc(a, b, oper));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject1
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UnitTest1
    {
        [TestMethod]
        public void Multiply() => Assert.AreEqual(4, Calculator.Calc(2, 2, "*"));
        [TestMethod]
        public void Devide() => Assert.AreEqual(1, Calculator.Calc(2, 2, "/"));
        [TestMethod]
        public void Plus() => Assert.AreEqual(4, Calculator.Calc(2, 2, "+"));
        [TestMethod]
        public void Minus() => Assert.AreEqual(0, Calculator.Calc(2, 2, "-"));
        [TestMethod]
        public void GetNumber() => Assert.AreEqual(1, Calculator.GetNumber("1"));
        [TestMethod]
        public void OutPut() => Assert.AreEqual(8, Calculator.OutPut("4 * 2"));
        [TestMethod]
        public void ExpDevide() => Assert.ThrowsException<DivideByZeroException>(() => Calculator.Calc(2.0m, 0.0m, "/"));
        [TestMethod]
        public void ExpOper() => Assert.ThrowsException<KeyNotFoundException>(() => Calculator.Calc(2.0m, 2.0m, "f"));
    }
}

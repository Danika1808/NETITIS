using System;
using NUnit.Framework;
using ConsoleApp24;

namespace NUnitTestProject2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Multiply() => Assert.AreEqual(4, Сalculator.Calc(2, 2, "*"));
        [Test]
        public void Devide() => Assert.AreEqual("Деление на нуль", Сalculator.Calc(2, 2, "/"));
        [Test]
        public void Plus()=> Assert.AreEqual(4, Сalculator.Calc(2, 2, "+"));
        [Test]
        public void Minus() => Assert.AreEqual(0, Сalculator.Calc(2, 2, "-"));
    }
}
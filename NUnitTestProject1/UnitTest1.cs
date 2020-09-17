using NUnit.Framework;
using ConsoleApp1;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Multiply()
        {
            Assert.AreEqual(4, Ñalculator.Calc(2, 2, "*"));
        }
        [Test]
        public void Devide()
        {
            Assert.AreEqual(1, Ñalculator.Calc(2, 2, "/"));
        }

        [Test]
        public void Plus()
        {
            Assert.AreEqual(4, Ñalculator.Calc(2, 2, "+"));
        }
        [Test]
        public void Minus()
        {
            Assert.AreEqual(0, Ñalculator.Calc(2, 2, "-"));
        }

        [Test]
        public void GetNumber()
        {
            Assert.AreEqual(1.0, Ñalculator.GetNumber("1,0"));
        }
        [Test]
        public void Input()
        {
            Assert.AreEqual(8, Ñalculator.Input("2 * 4"));
        }
    }
}
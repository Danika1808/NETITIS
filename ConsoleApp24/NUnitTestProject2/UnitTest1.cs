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
        public void Multiply()
        {
            Assert.AreEqual(4, Ñalculator.Calc(2, 2, "*"));
        }
        [Test]
        public void Devide()
        {
            Assert.AreEqual(1, Ñalculator.Calc(2,2, "/"));
        }
    }
}
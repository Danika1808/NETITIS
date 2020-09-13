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
            Assert.AreEqual(4, �alculator.Calc(2, 2, "*"));
        }
        [Test]
        public void Devide()
        {
            Assert.AreEqual(1, �alculator.Calc(2,2, "/"));
        }

        [Test]
        public void Plus()
        {
            Assert.AreEqual(4, �alculator.Calc(2, 2, "+"));
        }
        [Test]
        public void Minus()
        {
            Assert.AreEqual(0, �alculator.Calc(2, 2, "-"));
        }
    }
}
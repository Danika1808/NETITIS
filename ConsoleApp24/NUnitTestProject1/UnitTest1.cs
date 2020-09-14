using NUnit.Framework;
using ConsoleApp24;
namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Multiply() => Assert.AreEqual(4, Calculator.Calc(2, 2, "*"));
        [Test]
        public void Devide() => Assert.AreEqual("1", Calculator.Calc(2, 2, "/"));
        [Test]
        public void Plus() => Assert.AreEqual(4, Calculator.Calc(2, 2, "+"));
        [Test]
        public void Minus() => Assert.AreEqual(0, Calculator.Calc(2, 2, "-"));
    }
}
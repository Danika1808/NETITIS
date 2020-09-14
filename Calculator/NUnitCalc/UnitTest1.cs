using NUnit.Framework;
using Calculator;
namespace NUnitCalc
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Multiply() => Assert.AreEqual(4, CalculatorUtils.Calc(2, 2, "*"));
        [Test]
        public void Devide() => Assert.AreEqual("Деление на нуль", CalculatorUtils.Calc(2, 2, "/"));
        [Test]
        public void Plus() => Assert.AreEqual(4, CalculatorUtils.Calc(2, 2, "+"));
        [Test]
        public void Minus() => Assert.AreEqual(0, CalculatorUtils.Calc(2, 2, "-"));
    }
}
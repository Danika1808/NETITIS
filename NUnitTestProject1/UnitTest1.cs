using NUnit.Framework;
using ConsoleApp1;
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
public void Devide() => Assert.AreEqual(1, Calculator.Calc(2, 2, "/"));
[Test]
public void Plus() => Assert.AreEqual(4, Calculator.Calc(2, 2, "+"));
[Test]
public void Minus() => Assert.AreEqual(0, Calculator.Calc(2, 2, "-"));
[Test]
public void GetNumber() => Assert.AreEqual(1.0, Calculator.GetNumber("1,0"));
[Test]
public void OutPut() => Assert.AreEqual(8, Calculator.OutPut("4 * 2"));
[Test]
public void Split0() => Assert.AreEqual("1", Calculator.Split("1 / 2")[0]);
[Test]
public void Split1() => Assert.AreEqual("/", Calculator.Split("1 / 2")[1]);
[Test]
public void Split2() => Assert.AreEqual("2", Calculator.Split("1 / 2")[2]);
}
}

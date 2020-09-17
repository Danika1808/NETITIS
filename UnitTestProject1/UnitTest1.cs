using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
namespace UnitTestProject1
{
    [TestClass]
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
            public void Split0() => Assert.AreEqual("1", Calculator.Split("1 / 2")[0]);
            [TestMethod]
            public void Split1() => Assert.AreEqual("/", Calculator.Split("1 / 2")[1]);
            [TestMethod]
            public void Split2() => Assert.AreEqual("2", Calculator.Split("1 / 2")[2]);
        
    }
}

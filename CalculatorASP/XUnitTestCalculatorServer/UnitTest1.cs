using System.Net.Http;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestCalculatorServer
{
    public class UnitTest1
    {
        //[InlineData(new string[] { "6 - 4", "2 * 3", "7 - 6", "2 / 2", "1 * 1", "5 + 1" })]
        [Xunit.Theory]
        [MemberData(nameof(Expression))]
        public async void MathExpressionTest1Async(decimal x, string oper, decimal y, decimal result)
        {
            HttpClient client = new HttpClient();
            var expression = x + "+" + oper + "+" + y;
            expression = expression.Replace(',', '.');
            var responce = await client.GetAsync("http://localhost:51963?value=" + expression);
            var content = await responce.Content.ReadAsStringAsync();
            NUnit.Framework.Assert.AreEqual(result, decimal.Parse(content));
        }
        public static IEnumerable<object[]> Expression()
        {
            yield return new object[] {6.0M, "-", 4.0M, 2.0M};
            yield return new object[] { 2.0M, "*", 3.0M, 6.0M };
            yield return new object[] { 7.0M, "-", 6.0M, 1.0M };
            yield return new object[] { 2.0M, "%2F", 2.0M, 1.0M };
            yield return new object[] { 1.0M, "*", 1.0M, 1.0M };
            yield return new object[] { 5.0M, "%2B", 1.0M, 6.0M };
        }
    }
}

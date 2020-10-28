using System;
using System.Linq.Expressions;
using System.Net.Http;

namespace ExpressionTree
{
    class Responce
    {
        public static string GetPesponsing(decimal a, decimal b, string oper)
        {
            string expression = a + oper + b;
            HttpClient client = new HttpClient();
            var responce = client.GetAsync("http://localhost:51963?value=" + expression).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            return content;
        }
    }
}

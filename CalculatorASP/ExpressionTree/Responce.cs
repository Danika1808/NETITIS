using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ExpressionTree
{
    class Responce
    {
        public static string GetResponsePlus(Expression a, Expression b)
        {
            string a1 = a.ToString();
            string b1 = b.ToString();
            string oper = "%2B";
            var ans = GetPesponsing(a1, b1, oper);
            return ans;
        }
        public static string GetResponseMinus(Expression a, Expression b)
        {
            string a1 = a.ToString();
            string b1 = b.ToString();
            string oper = "-";
            var ans = GetPesponsing(a1, b1, oper);
            return ans;
        }
        public static string GetResponseDivide(Expression a, Expression b)
        {
            string a1 = a.ToString();
            string b1 = b.ToString();
            string oper = "%2F";
            var ans = GetPesponsing(a1, b1, oper);
            return ans;
        }
        public static string GetResponseMultply(Expression a, Expression b)
        {
            string a1 = a.ToString();
            string b1 = b.ToString();
            string oper = "*";
            var ans = GetPesponsing(a1, b1, oper);
            return ans;
        }
        public static string GetPesponsing(string a, string b, string oper)
        {
            string expression = a + oper + b;
            HttpClient client = new HttpClient();
            var responce = client.GetAsync("http://localhost:51963?value=" + expression).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            return content;
        }
    }
}

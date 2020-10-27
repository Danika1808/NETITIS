﻿using System;
using System.Linq.Expressions;
using System.Net.Http;

namespace ExpressionTree
{
    class Responce
    {  
        public static string GetPesponsing(Expression a, Expression b, string oper)
        {
            oper = oper switch
            {
                "+" => "%2B",
                "-" => "-",
                "/" => "%2F",
                "*" => "*",
                _ => throw new NotImplementedException()
            };
            string expression = a.ToString() + oper + b.ToString();
            HttpClient client = new HttpClient();
            var responce = client.GetAsync("http://localhost:51963?value=" + expression).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            return content;
        }
    }
}

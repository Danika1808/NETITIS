using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CalculatorASP
{
    public class CalculatorMiddleware
    {
        private readonly RequestDelegate _next;
        public CalculatorMiddleware(RequestDelegate next) => _next = next;        
        public async Task InvokeAsync(HttpContext context)
        {
            var value = context.Request.Query["value"];
            var calclulator = new Calculator.Calculator();
            var ans = calclulator.Calc(value);
            await context.Response.WriteAsync(ans.ToString());
            await _next.Invoke(context);
        }     
    }
}

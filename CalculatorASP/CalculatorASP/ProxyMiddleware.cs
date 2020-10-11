using Calculator.DesignPatterns.Proxy;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CalculatorASP
{
    public class ProxyMiddleware
    {
        private readonly RequestDelegate _next;

        public ProxyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var value = context.Request.Query["value"];
            var check = Proxy.CheckAccess(value);
            if (check)
               await _next.Invoke(context);
            else
                context.Response.StatusCode = 403;
        }
    }
}

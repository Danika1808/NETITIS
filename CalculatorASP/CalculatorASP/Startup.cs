using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CalculatorASP
{

public class Startup
    {
        public Startup()
        {

        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseToken();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("HelloWorld");
            });
        }
    }
}

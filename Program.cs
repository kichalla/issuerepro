using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
                
            var host = new WebHostBuilder()
                        .UseConfiguration(config)
                        .UseKestrel()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseStartup<Startup>()
                        .Build();

            host.Run();
        }
    }
    
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello,, World!");
            });
        }
    }
}

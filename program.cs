using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
namespace HelloWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                        .UseServer("Microsoft.AspNetCore.Server.Kestrel")
                        .UseApplicationBasePath(Directory.GetCurrentDirectory())
                        .UseDefaultConfiguration(args)
                        .UseStartup<Startup>()
                        .Build();

            host.Run();
        }
    }
        public class Startup
        {
                public void Configure(IApplicationBuilder app)
                {
                        app.UseForwardedHeaders(new ForwardedHeadersOptions
                        {
                                ForwardedHeaders = ForwardedHeaders.All
                        });

                        app.Run(context =>
                        {
                                return context.Response.WriteAsync("Hello Core World!");
                        });
                }
        }
}

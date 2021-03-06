using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Dos.User.Api.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
              Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
                .ConfigureKestrel(options => options.AddServerHeader = false)
                .ConfigureAppConfiguration((buildercontext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory());
    }
}

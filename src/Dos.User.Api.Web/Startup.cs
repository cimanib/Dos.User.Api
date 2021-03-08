using Autofac;
using Dos.User.Api.Web.Data;
using Dos.User.Api.Web.Extensions;
using Dos.User.Api.Web.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Dos.User.Api.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddHttpContextAccessor()
                .AddCustomSwagger()
                .AddCustomMvc()
                .AddMediatR(typeof(Startup).Assembly)
                .AddCustomApiFeatures()
                .AddCustomConfiguration()
                .AddCustomHealthChecks()
                .AddCustomDb(Configuration);

            return new ContainerBuilder()
                   .Registration(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
              .UseCors("UserPolicy")
              .UseCorsMiddleware()
              .UseExceptionHandler("/error")
              .UseSwagger()
              .UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint("v1/swagger.json", "User Api");
              })
             
              .UseRouting()
              .UseAuthorization()
              .UseEndpoints(endpoints =>
              {
                endpoints.MapControllers();
              })
             .UseHealthChecks("/hc", new HealthCheckOptions
             {
             });
             DataGenerator.Seed(System.IO.File.ReadAllText(@"Data.json"), app.ApplicationServices);
        }
    }
}
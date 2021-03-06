using Autofac;
using Autofac.Extensions.DependencyInjection;
using DocumentFormat.OpenXml.EMMA;
using Dos.User.Api.Configuration;
using Dos.User.Api.Data.Sql;
using Dos.User.Api.IoC.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Dos.User.Api.Web.Extensions
{
    public static class StartupExtensions
    {
        public static AutofacServiceProvider Registration(this ContainerBuilder container, IServiceCollection services)
        {
            container.Populate(services);

            container
                .RegisterModule(new MediatorModule())
                .RegisterModule(new ApplicationModule())
                .RegisterModule(new InfrastructureModule());


            return new AutofacServiceProvider(container.Build());
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "User service api", Version = "v1", });
            });
            return services;
        }
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.EnableEndpointRouting = true;
                    //options.Filters.Add(new AuthorizeFilter());
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .AddControllersAsServices();

            return services;
        }
        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services)
        {
            services
                .AddOptions()
                .Configure<ApiBehaviorOptions>(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            return services;
        }
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            services
                .AddHealthChecks();
            return services;
        }


        public static IServiceCollection AddCustomDb(this IServiceCollection services)
        {
            services
                .AddDbContext<UserDbContext>(opt => opt.UseInMemoryDatabase("dos_users"));
            return services;
        }

        public static IServiceCollection AddCustomApiFeatures(this IServiceCollection services)
            => services
                .AddVersionedApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                })
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.ApiVersionReader = new HeaderApiVersionReader("X-Api-Version");
                })
                .AddRouting(options =>
                {
                    options.LowercaseUrls = true;
                });
    }
}

   


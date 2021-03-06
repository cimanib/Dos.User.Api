using Autofac;
using Dos.User.Api.Data.Queries;
using Dos.User.Api.Data.Sql.EntityConfigurations;
using Dos.User.Api.Data.Sql.Repositories;
using Dos.User.Api.Domain.AggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dos.User.Api.IoC.Configuration
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
              .RegisterType<UserEntityTypeConfiguration>()
              .As<IEntityTypeConfiguration<UserEntity>>()
              .InstancePerLifetimeScope();

            builder
                .RegisterType<UserQueryRespository>()
                .As<IUserRespository>()
                .InstancePerLifetimeScope();
        }
    }
}
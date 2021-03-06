using Autofac;
using Dos.User.Api.Handlers;
using MediatR;
using System.Reflection;
using Module = Autofac.Module;

namespace Dos.User.Api.Configuration
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(GetUsersQueryHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
        }
    }
}
using Autofac;
using MediatR;
using System.Reflection;

namespace Dos.User.Api.IoC.Configuration
{
    public class MediatorModule
         : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
        }
    }
}

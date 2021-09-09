using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MessageGenerator.Domain.Extensions;

namespace MessageGenerator.Database
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(ThisAssembly)
                .RegisterGenericMediatR(ThisAssembly);

            base.Load(builder);
        }
    }
}

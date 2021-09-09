using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MessageGenerator.Application.BackgroundTasks.Base;
using MessageGenerator.Domain.Extensions;
using MessageGenerator.Services;

namespace MessageGenerator.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IBackgroundTask>()
                .As<IBackgroundTask>();

            builder.RegisterMediatR(ThisAssembly)
                .RegisterGenericMediatR(ThisAssembly);

            builder.RegisterModule<DomainModule>();

            base.Load(builder);
        }
    }
}

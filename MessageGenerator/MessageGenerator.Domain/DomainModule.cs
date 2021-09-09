using Autofac;
using AutoMapper;
using System.Collections.Generic;

namespace MessageGenerator.Services
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AssignableTo<Profile>().As<Profile>();

            builder.Register(context => new MapperConfiguration(cfg => cfg.AddProfiles(context.Resolve<IEnumerable<Profile>>())))
                .AsSelf()
                .SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}

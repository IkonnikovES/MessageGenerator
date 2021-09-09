using Autofac;
using Autofac.Util;
using MediatR;
using System;
using System.Linq;
using System.Reflection;

namespace MessageGenerator.Domain.Extensions
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder RegisterGenericMediatR(this ContainerBuilder builder, Assembly assembly)
        {
            RegisterPartialGenerics(builder, assembly, typeof(IRequestHandler<,>));

            return builder;
        }

        private static ContainerBuilder RegisterPartialGenerics(ContainerBuilder builder, Assembly assembly, Type interfaceType)
        {
            var generics = assembly.GetLoadableTypes()
                .Where(y => y.GetInterfaces().Any(z => IsGenericType(z, interfaceType)))
                .Where(x => x.IsGenericType);

            foreach (var item in generics)
            {
                builder.RegisterGeneric(item).As(interfaceType);
            }

            return builder;
        }

        private static bool IsGenericType(Type type, Type genericType) => type.IsGenericType && type.GetGenericTypeDefinition() == genericType;
    }
}

using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using ExampleWebApiCore.Converters;
using ExampleWebApiCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleWebApiCore.Infrastructure
{
    public static class DependencyInjector
    {
        private static IContainer _rootContainer;
        public static IContainer BuildContainer(IServiceCollection services)
        {
            if (_rootContainer != null) return _rootContainer;
            var builder = new ContainerBuilder();
            builder.Populate(services);
            Configurate(builder);
            _rootContainer = builder.Build();
            return _rootContainer;
        }

        private static void Configurate(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryService<>))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Context>().As<DbContext>();

            #region AutomapperRegistration

            //Generic converters
            builder.RegisterGeneric(typeof(BaseIdToEntityConverter<>)).AsSelf().InstancePerLifetimeScope();
            //Non generic converters
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITypeConverter<,>)))
                .AsSelf().InstancePerLifetimeScope();

            builder.Register(c => new MapperConfiguration(cfg => cfg.AddProfiles(Assembly.GetExecutingAssembly())))
                .AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                    .CreateMapper(c.Resolve<IComponentContext>().Resolve))
                .As<IMapper>().InstancePerLifetimeScope();

            #endregion
        }

        public static ILifetimeScope BeginNewLiftimeScope()
        {
            return _rootContainer.BeginLifetimeScope();
        }
        public static T Resolve<T>()
        {
            return _rootContainer.Resolve<T>();
        }
        public static object Resolve(Type t)
        {
            return _rootContainer.Resolve(t);
        }
    }
}
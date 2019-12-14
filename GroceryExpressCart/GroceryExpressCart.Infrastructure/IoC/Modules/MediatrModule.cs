using System;
using System.Reflection;
using Autofac;
using GroceryExpressCart.Infrastructure.Command;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;

namespace GroceryExpressCart.Infrastructure.IoC.Modules
{
    public class MediatrModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            var mediatrOpenTypes = new[]
            {
            typeof(IRequestHandler<,>),
            typeof(INotificationHandler<>)
        };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(CreateUserCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));

            builder.Register<ServiceFactory>(component =>
            {
                var componentContext = component.Resolve<IComponentContext>();
                return type => componentContext.Resolve(type);
            });
        }
    }
}

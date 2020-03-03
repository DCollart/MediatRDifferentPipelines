using System;
using System.Reflection;
using MediatR;
using MediatRDifferentPipelines.BehaviorPipelines;
using MediatRDifferentPipelines.Command;
using MediatRDifferentPipelines.Query;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace MediatRDifferentPipelines
{
    class Program
    {
        static void Main(string[] args)
        {

            var mediator = GetMediatorWithSimpleInjector();

            Console.WriteLine("Query");
            mediator.Send(new TestQuery());

            Console.WriteLine();

            Console.WriteLine("Command");
            mediator.Send(new TestCommand());


            Console.ReadLine();
        }

        private static IMediator GetMediatorWithSimpleInjector()
        {
            var container = new Container();
            var assembly = Assembly.GetExecutingAssembly();
            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assembly);
            container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                typeof(CommonBehaviorPipeline<,>),
                typeof(CommandBehaviorPipeline<,>),
                typeof(QueryBehaviorPipeline<,>)
            });

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);
            return container.GetInstance<IMediator>();
        }

        private static IMediator GetMediatorWithDefaultIOC()
        {
            var serviceCollection = new ServiceCollection();
            var assembly = Assembly.GetExecutingAssembly();
            serviceCollection.AddMediatR(assembly);
            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommonBehaviorPipeline<,>));
            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandBehaviorPipeline<,>));
            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(QueryBehaviorPipeline<,>));


            var provider = serviceCollection.BuildServiceProvider();

            return provider.GetService<IMediator>();
        }
    }
}

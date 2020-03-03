using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatRDifferentPipelines.BehaviorPipelines
{
    public class CommandBehaviorPipeline<TIn, TOut> : IPipelineBehavior<TIn, TOut>
        where TIn : ICommand<TOut>
    {
        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            Console.WriteLine($"{this.GetType().Name}");
            return await next();

        }
    }
}
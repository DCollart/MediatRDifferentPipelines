using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatRDifferentPipelines.BehaviorPipelines
{
    public class CommonBehaviorPipeline<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            Console.WriteLine($"{this.GetType().Name}");
            return await next();

        }
    }
}
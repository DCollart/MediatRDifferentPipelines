using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatRDifferentPipelines
{
    public class TestQueryHandler : IRequestHandler<TestQuery, string>
    {
        public Task<string> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{this.GetType().Name}");
            return Task.FromResult("Hello");
        }
    }
}
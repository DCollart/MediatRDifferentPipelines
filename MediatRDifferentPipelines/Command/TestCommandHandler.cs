using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatRDifferentPipelines
{
    public class TestCommandHandler : IRequestHandler<TestCommand, bool>
    {
        public Task<bool> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{this.GetType().Name}");
            return Task.FromResult(true);
        }
    }
}
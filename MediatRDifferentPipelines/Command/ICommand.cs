using MediatR;

namespace MediatRDifferentPipelines
{
    public interface ICommand<T> : IRequest<T>
    {
        
    }
}
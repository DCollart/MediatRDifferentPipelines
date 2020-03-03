using MediatR;

namespace MediatRDifferentPipelines
{
    public interface IQuery<T> : IRequest<T>
    {
        
    }
}
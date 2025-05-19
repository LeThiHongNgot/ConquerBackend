
using ConquerBackend.Domain.Event;
using MediatR;
using System.Windows.Input;

namespace ConquerBackend.Application.Common
{
    public interface IDispatch 
    {
        Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;

        Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);

        Task PublishAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken = default) where TEvent : IDomainEvent;
    }

}

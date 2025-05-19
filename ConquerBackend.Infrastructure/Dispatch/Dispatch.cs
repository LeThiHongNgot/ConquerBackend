using ConquerBackend.Application.Common;
using ConquerBackend.Domain.Event;
using MediatR;
using System.Windows.Input;

public class Dispatch : IDispatch
{
    private readonly IMediator _mediator;

    public Dispatch(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gửi (Send) một command không trả về kết quả (void/unit).
    /// Dùng để thực thi các thao tác thay đổi trạng thái hệ thống mà không cần trả về dữ liệu.
    /// </summary>
    public Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
    {
        return _mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Gửi (Send) một yêu cầu IRequest trả về kết quả (query hoặc command trả về dữ liệu).
    /// Dùng để lấy dữ liệu hoặc thực thi command trả về kết quả.
    /// </summary>
    public Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return _mediator.Send(request, cancellationToken);
    }

    /// <summary>
    /// Phát (Publish) một sự kiện (domain event) tới tất cả các handler đăng ký lắng nghe sự kiện đó.
    /// Dùng để xử lý các nghiệp vụ phụ hoặc side effects không trả về kết quả.
    /// </summary>
    public Task PublishAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken = default) where TEvent : IDomainEvent
    {
        return _mediator.Publish(domainEvent, cancellationToken);
    }
}

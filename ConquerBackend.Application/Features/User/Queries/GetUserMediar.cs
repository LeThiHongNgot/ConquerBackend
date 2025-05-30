using ConquerBackend.Application.Features.User.DTOs;
using MediatR;

namespace ConquerBackend.Application.Features.User.Queries
{
    public record GetUserListQuery() : IRequest<IEnumerable<UsersDTO>>;
}

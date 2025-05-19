using ConquerBackend.Application.Features.User.DTOs;
using MediatR;

namespace ConquerBackend.Application.Features.User.Command
{
    public record InsertUserCommand(UpdateUser user) : IRequest<UsersDTO>;

}

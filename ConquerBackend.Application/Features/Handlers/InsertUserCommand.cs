using ConquerBackend.Application.Features.User.Command;
using ConquerBackend.Application.Features.User.DTOs;
using ConquerBackend.Application.Features.User.Interface;
using MediatR;

namespace ConquerBackend.Application.Features.Handlers
{
    public class InsertUserCommandHandler(IUserService _userService) : IRequestHandler<InsertUserCommand, UsersDTO>
    {
        public async Task<UsersDTO> Handle(InsertUserCommand command, CancellationToken cancellation)
        {
            return await _userService.CreateAsync(command.user, cancellation); // ✅ Gửi đúng kiểu UpdateUser
        }
    }

}

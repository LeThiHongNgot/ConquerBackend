using ConquerBackend.Application.Features.User.DTOs;
using ConquerBackend.Application.Features.User.Interface;
using ConquerBackend.Application.Features.User.Queries;
using MediatR;

namespace ConquerBackend.Application.Features.Handlers
{
    public class GetUserMediarHandler(IGetUserQuery _userQuery) :IRequestHandler<GetUserListQuery,IEnumerable<UsersDTO>>
    {
        public async Task<IEnumerable<UsersDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return await _userQuery.GetAll(cancellationToken);
        }
    }
}

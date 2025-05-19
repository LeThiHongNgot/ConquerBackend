using ConquerBackend.Application.Features.User.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Application.Features.User.Queries
{
    public record GetUserListQuery() : IRequest<IEnumerable<UsersDTO>>;
}

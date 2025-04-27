using ConquerBackend.Application.Features.User.DTOs;
using ConquerBackend.Domain.Dapper;
using ConquerBackend.Shared.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Application.Features.User.Interface
{
    public interface IGetUserQuery : IServiceDependency
    {
        Task<List<UsersDTO>> GetAll(CancellationToken cancellation);
    }
}

using ConquerBackend.Application.Features.User.DTOs;
using ConquerBackend.Shared.DependencyInjection;

namespace ConquerBackend.Application.Features.User.Interface
{
    public interface IGetUserQuery : IServiceDependency
    {
        Task<List<UsersDTO>> GetAll(CancellationToken cancellation);
        Task<List<UsersDTO>> GetAllSaveRedis(CancellationToken cancellation);
    }
}

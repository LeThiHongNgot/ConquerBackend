using ConquerBackend.Application.Features.User.DTOs;
using ConquerBackend.Domain.Entities;
using ConquerBackend.Domain.Entities.ConquerBackend;
using ConquerBackend.Domain.Paging;
using ConquerBackend.Shared.DependencyInjection;
using System.Linq.Expressions;
namespace ConquerBackend.Application.Features.User.Interface
{
    public interface IUserService : IServiceDependency
    {
        Task<IEnumerable<UsersDTO>> GetAllAsync(CancellationToken cancellation);
        Task<PagedResult<UsersModel>> GetAsync(UsersDTO search,PageParam param,CancellationToken cancellationToken = default);
        Task<UsersDTO?> GetByIdAsync(Guid id);
        Task<UsersDTO> CreateAsync(UpdateUser input, CancellationToken cancellation);
        Task<UsersDTO> UpdateAsync(Guid id, UpdateUser input);
        Task<bool> DeleteAsync(Guid id);
    }
}

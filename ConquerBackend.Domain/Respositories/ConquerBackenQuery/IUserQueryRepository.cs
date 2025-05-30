using ConquerBackend.Domain.Entities.ConquerBackend;

namespace ConquerBackend.Domain.Respositories.ConquerBackenQuery
{
    public interface IUserQueryRepository: IScopedDependency
    {
        Task<List<UsersModel>> GetAll(CancellationToken cancellation);
    }
}

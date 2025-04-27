using ConquerBackend.Domain.Entities.ConquerBackend;

namespace ConquerBackend.Domain.Respositories.ConquerBackend
{
    public interface IUserRepository : IRepository<UsersModel, Guid>, IScopedDependency
    {
      
    }
}

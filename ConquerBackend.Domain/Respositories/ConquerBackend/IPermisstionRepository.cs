using ConquerBackend.Domain.Entities.ConquerBackend;

namespace ConquerBackend.Domain.Respositories.ConquerBackend
{
    public interface IPermisstionRepository : IRepository<PermissionsModel,Guid>, IScopedDependency
    {
    }
}

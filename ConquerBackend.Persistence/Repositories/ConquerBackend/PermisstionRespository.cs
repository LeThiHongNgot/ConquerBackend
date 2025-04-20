using AutoMapper;
using ConquerBackend.Domain;
using ConquerBackend.Domain.Entities.ConquerBackend;
using ConquerBackend.Domain.Respositories.ConquerBackend;
using ConquerBackend.Persistence.Context;

namespace ConquerBackend.Persistence.Repositories.ConquerBackend
{
    internal class PermisstionRespository(ConquerBackendContext context, IMapper mapper) : Repository<PermissionsModel, Guid>(context, mapper), IPermisstionRepository, IScopedDependency
    {

    }
}

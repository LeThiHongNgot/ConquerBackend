using AutoMapper;
using ConquerBackend.Domain;
using ConquerBackend.Domain.Entities.ConquerBackend;
using ConquerBackend.Domain.Respositories;
using ConquerBackend.Domain.Respositories.ConquerBackend;
using ConquerBackend.Persistence.Context;

namespace ConquerBackend.Persistence.Repositories.ConquerBackend
{
    public class RoleRepository(ConquerBackendContext context,IUnitOfWork unitOfWork) : Repository<RolesModel, Guid>(context, unitOfWork), IRoleRepository
    {

    }

}

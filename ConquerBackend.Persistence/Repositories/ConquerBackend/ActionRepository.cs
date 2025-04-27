using AutoMapper;
using ConquerBackend.Domain;
using ConquerBackend.Domain.Entities.ConquerBackend;
using ConquerBackend.Domain.Respositories;
using ConquerBackend.Domain.Respositories.ConquerBackend;
using ConquerBackend.Persistence.Context;

namespace ConquerBackend.Persistence.Repositories.ConquerBackend
{
    public class ActionRepository(ConquerBackendContext context,IUnitOfWork unitOfWork) : Repository<ActionsModel, Guid>(context, unitOfWork), IActionRepository
    {

    }
}

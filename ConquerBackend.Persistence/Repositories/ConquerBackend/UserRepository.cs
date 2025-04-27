using AutoMapper;
using ConquerBackend.Domain;
using ConquerBackend.Domain.Entities.ConquerBackend;
using ConquerBackend.Domain.Respositories;
using ConquerBackend.Domain.Respositories.ConquerBackend;
using ConquerBackend.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Persistence.Repositories.ConquerBackend
{
    public class UserRepository(ConquerBackendContext context,IUnitOfWork unitOfWork) : Repository<UsersModel, Guid>(context, unitOfWork), IUserRepository
    {
       
    }
}

using ConquerBackend.Domain.Entities;
using ConquerBackend.Domain.Entities.ConquerBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Respositories.ConquerBackend
{
    public interface IUserRepository : IRepository<UsersModel, Guid>
    {
      
    }
}

using ConquerBackend.Domain.Entities.ConquerBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Respositories.ConquerBackend
{
    public interface IPermisstionRepository : IRepository<PermissionsModel,Guid>
    {
    }
}

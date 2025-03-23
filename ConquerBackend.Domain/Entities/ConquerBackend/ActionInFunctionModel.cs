using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities.ConquerBackend
{
    public class ActionInFunctionModel : FullAuditedEntity<Guid>
    {
        public int RoleId { get; set; }
        public int FunctionId { get; set; }
    }
}

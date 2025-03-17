using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public class ActionInFunctionModel : AuditInfoModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int RoleId { get ; set; }
        public int FunctionId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public class PermissionsModel: AuditInfoModel
    {
        public int RoleId { get; set; }
        public int FunctionId { get; set; }
        public int ActionId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public class RolesModel: AuditInfoModel
    {
        public string Description {  get; set; }
        public string RoleCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities.ConquerBackend
{
    public class PermissionsModel : BaseEntity<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid FunctionId { get; set; }
        public Guid ActionId { get; set; }
    }
}

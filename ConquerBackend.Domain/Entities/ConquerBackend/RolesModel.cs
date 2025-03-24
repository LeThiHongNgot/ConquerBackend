using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ConquerBackend.Domain.Entities.ConquerBackend
{
    public class RolesModel : FullAuditedEntity<Guid>, IdentityRole<Guid>
    {
        public string Description { get; set; }
        public string RoleCode { get; set; }
    }
}

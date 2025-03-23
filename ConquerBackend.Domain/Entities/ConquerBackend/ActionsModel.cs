using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities.ConquerBackend
{
    public class ActionsModel : FullAuditedEntity<Guid>,Active
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActived { get; set; }
    }
}

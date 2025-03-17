using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public class AuditInfoModel
    {
        public int OrderId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAdd { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAdd { get; set; }
        public int IsDeleted { get; set; }
        
    }
}

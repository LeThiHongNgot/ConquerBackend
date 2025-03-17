using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public class ActionsModel : AuditInfoModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int IsActived { get; set; }
    }
}

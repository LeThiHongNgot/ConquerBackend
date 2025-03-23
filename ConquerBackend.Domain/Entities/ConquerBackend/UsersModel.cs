using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities.ConquerBackend
{
    public class UsersModel : FullAuditedEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDirector { get; set; }
        public bool  IsHeadOfDepartment { get; set; }
        public Guid ManagerId { get; set; }
        public Guid PositionId { get; set; }


    }
}
    
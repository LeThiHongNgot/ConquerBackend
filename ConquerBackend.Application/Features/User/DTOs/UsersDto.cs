using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Application.Features.User.DTOs
{
    public class UsersDTO
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; } = default!;
        public string? LastName { get; set; } = default!;
        public string? FullName { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; }
        public bool? IsDirector { get; set; }
        public bool? IsHeadOfDepartment { get; set; }
        public Guid? ManagerId { get; set; }
        public Guid? PositionId { get; set; }
    }

}

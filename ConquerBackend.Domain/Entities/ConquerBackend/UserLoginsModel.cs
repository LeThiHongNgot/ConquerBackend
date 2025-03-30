using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities.ConquerBackend
{
    public class UserLoginsModel:IdentityUserLogin<Guid>
    {
    }
}

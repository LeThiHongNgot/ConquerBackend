using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Persistence.Constract
{
    public class DatabaseConstants
    {
        public class TableNames
        {
            // Các bảng trong cơ sở dữ liệu
            public const string UsersTable = "Users";
            public const string RolesTable = "Roles";
            public const string ActionsTable = "Actions";
            public const string PermissionsTable = "Permissions";
            public const string FunctionsTable = "Functions";
            public const string UserClaimsTable = "UserClaims";
            public const string UserTokensTable = "UserTokens";
            public const string ActionInFunctionTable = "ActionInFunction";
            public const string UserLoginsTable = "UserLogins";
            public const string UserRolesTable = "UserRoles";
            public const string RoleClaimsTable = "RoleClaims";
        }
    }

}

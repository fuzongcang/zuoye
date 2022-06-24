using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEF;
using Rbac.Entity;

namespace RbacRepository.Role
{
    public class RoleDto:BaseDTO<Rbac.Entity.Role, int>,IRoleDto
    {
        public RoleDto(MyDbContext db)
        {
            this.db = db;
        }
    }
}

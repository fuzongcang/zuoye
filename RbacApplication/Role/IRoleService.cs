using RbacApplication.Role.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication.Role
{
    public interface IRoleService:IBaseService<Rbac.Entity.Role, RoleDto>
    {
        int SavePermission(PermissionDto permission);
    }
}

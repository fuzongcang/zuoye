using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;

namespace RbacRepository
{
    public interface IRoleDto:IBaseDTO<Rbac.Entity.Role,int>
    {
    }
}

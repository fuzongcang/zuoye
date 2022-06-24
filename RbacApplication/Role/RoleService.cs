using AutoMapper;
using RbacRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication.Role
{
    public class RoleService : BaseService<Rbac.Entity.Role, RoleDto>, IRoleService
    {
        private readonly IRoleDto baseService;

        public RoleService(IRoleDto baseService, IMapper mapper) : base(baseService, mapper)
        {
            this.baseService = baseService;
        }
    }
}

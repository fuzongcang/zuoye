using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacRepository.AdminRole
{
    public class AdminRoleRepository : BaseDTO<Rbac.Entity.AdminRole, int>, IAdminRoleRepository
    {
        public AdminRoleRepository(MyDbContext db)
        {
            this.db = db;
        }
    }
}

using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacRepository
{
    public class AdminRepository:BaseDTO<Rbac.Entity.Admin,int>,IAdminRepository
    {
        public AdminRepository(MyDbContext context)
        {
            this.db = context;
        }
    }
}

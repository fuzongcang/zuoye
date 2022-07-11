using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication.Admins.Dto
{
    public class AdminRoleDto
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int RoleId { get; set; }
    }
}

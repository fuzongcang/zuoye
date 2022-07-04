using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication.Role.Dto
{
    public class PermissionDto
    {
        public int[] MenuId { get; set; }
        public int RoleId { get; set; }
    }
}

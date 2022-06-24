using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    [Table("Role")]
    public class Role: BaseClass
    {
        ///<summary>
        ///角色Id
        ///</summary>
        [Key]
        public int RoleId { get; set; }

        ///<summary>
        ///角色名称
        ///</summary>
        public string RoleName { get; set; }
    }
}

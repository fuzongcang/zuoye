using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rbac.Entity
{
    [Table("AdminRole")]
    public class AdminRole
    {
        [Key]
        public int Id { get; set; }
        public long AdminId { get; set; }
        public int RoleId { get; set; }
    }
}

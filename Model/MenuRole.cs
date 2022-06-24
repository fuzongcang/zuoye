using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rbac.Entity
{
    [Table("MenuRole")]
    public class MenuRole
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
    }
}

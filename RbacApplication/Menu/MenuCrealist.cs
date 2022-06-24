using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication
{
    public class MenuCrealist
    {
        public int value { get; set; }
        public string label { get; set; }
        public List<MenuCrealist> children { get; set; } = new List<MenuCrealist>();
    }
}

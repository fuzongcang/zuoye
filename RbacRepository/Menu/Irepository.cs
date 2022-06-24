using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacRepository
{
    public interface Irepository
    {
        List<Menu> GetAll();
        int Add(Menu meun);
        int Del(Menu menu);
        int Edit(Menu menu);
    }
}

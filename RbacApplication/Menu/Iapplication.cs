using Rbac.Entity;
using System;
using System.Collections.Generic;

namespace RbacApplication
{
    public interface Iapplication
    {
        List<MenuDto> GetAll();
        List<MenuCrealist> GetList();
        int Add(Menu menu);
        int Del(Menu menu);
        int Edit(Menu menu);
    }
}

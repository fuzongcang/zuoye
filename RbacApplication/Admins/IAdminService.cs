using Rbac.Entity;
using RbacApplication.Admins.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication.Admins
{
    public interface IAdminService:IBaseService<Rbac.Entity.Admin, AdminDto>
    {
        ResultDto Register(AdminDto dto);
        TokenDto Login(LoginDto dto);
        Tuple<List<Admin>,int>  Page(int Pindex = 1,int Psize = 2);
        int Shan(int id);
       
    }
}

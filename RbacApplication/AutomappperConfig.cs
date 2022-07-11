using AutoMapper;
using RbacApplication.Admins.Dto;
using RbacApplication.Role.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication
{
    public class AutomappperConfig:Profile
    {
        public AutomappperConfig()
        { 
            CreateMap<RoleDto,Rbac.Entity.Role>().ReverseMap();
            CreateMap<AdminDto,Rbac.Entity.Admin>().ReverseMap();
            CreateMap<PermissionDto, Rbac.Entity.MenuRole>().ReverseMap();
            CreateMap<AdminRoleDto, Rbac.Entity.AdminRole>().ReverseMap();
        }
    }
}

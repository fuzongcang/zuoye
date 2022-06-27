using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RbacApplication;
using RbacApplication.Role;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]//标签，特性 Attribute
    public class RoleController : ControllerBase
    {
        private readonly IRoleService role;

        public RoleController(IRoleService role)
        {
            this.role = role;
        }

        [HttpPost]
        public IActionResult Add(RoleDto dto)
        {
            return Ok(role.Add(dto));
        }

        [HttpGet]
        public IActionResult Show()
        {
            return new JsonResult(role.GetAll());
        }

        [HttpGet]
        public IActionResult GeiId(int id)
        {
            return new JsonResult(role.GetById(id));
        }

        [HttpDelete]
        public IActionResult Del(int id)
        {
            return Ok(role.Delete(id));
        }

        [HttpPut]
        public IActionResult Upd(RoleDto r)
        {
            return Ok(role.Update(r));
        }
    }
}

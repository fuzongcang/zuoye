using Microsoft.AspNetCore.Mvc;
using RbacApplication.Admins;
using RbacApplication.Admins.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService admin;

        public AdminsController(IAdminService admin)
        {
            this.admin = admin;
        }
        [HttpPost]
        public IActionResult Register(AdminDto dto)
        {
            return Ok(admin.Register(dto));
        }
        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            return Ok(admin.Login(dto));
        }
        [HttpGet]
        public IActionResult Page(int Pindex = 1, int Psize = 2)
        {
            return Ok(admin.Page(Pindex,Psize));
        }
    }
}

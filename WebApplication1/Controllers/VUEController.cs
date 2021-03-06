using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using RbacApplication;
using RbacRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]//标签，特性 Attribute
    public class VUEController : ControllerBase
    {
        public VUEController(Iapplication iapplication)
        {
            prostsfjkst = iapplication;
        }

        public Iapplication prostsfjkst { get; }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(prostsfjkst.GetAll());
        }
        /// <summary>
        /// 级联菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(prostsfjkst.GetList());
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Menu menu)
        {
            return Ok(prostsfjkst.Add(menu));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(Menu menu)
        {
            return Ok(prostsfjkst.Edit(menu));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost] 
        public IActionResult Del(Menu menu)
        {
            return Ok(prostsfjkst.Del(menu));
        }
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Show()
        {
            return Ok(prostsfjkst.Show());
        }
    }
}

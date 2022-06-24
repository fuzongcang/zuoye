using Rbac.Entity;
using RbacRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication
{
    public class Application:Iapplication
    {
        public Application(Irepository instpsnsjf)
        {
            fjslkfsfkejfsl = instpsnsjf;
        }

        public Irepository fjslkfsfkejfsl { get; }

        public List<MenuDto> GetAll()
        {
            var list = fjslkfsfkejfsl.GetAll();
            List<MenuDto> menus = new List<MenuDto>();

            var menu = list.Where(s => s.ParentId == 0).Select(s => new MenuDto
            {
                MenuId = s.MenuId,
                MenuName = s.MenuName,
                LinkUrl = s.LinkUrl,
            }).ToList();

            GetNodes(menu);
            return menu;
        }
        /// <summary>
        /// 递归
        /// </summary>
        /// <returns></returns>
        private void GetNodes(List<MenuDto> menus)
        {
            var list = fjslkfsfkejfsl.GetAll();
            foreach (var item in menus)
            {
                var _list = list.Where(s => s.ParentId == item.MenuId).Select(s => new MenuDto
                {
                    MenuId = s.MenuId,
                    MenuName = s.MenuName,
                    LinkUrl = s.LinkUrl,
                }).ToList();
                item.children.AddRange(_list);
                GetNodes(_list);
            }
        }
        

        /// <summary>
        /// 级联菜单
        /// </summary>
        /// <returns></returns>
        public List<MenuCrealist> GetList()
        {
            var list = fjslkfsfkejfsl.GetAll();
            List<MenuCrealist> menus = new List<MenuCrealist>();

            var menu = list.Where(s => s.ParentId == 0).Select(s => new MenuCrealist
            {
                value = s.MenuId,
                label = s.MenuName,
            }).ToList();

            GetNodesList(menu);
            return menu;
        }

        private void GetNodesList(List<MenuCrealist> menus)
        {
            var list = fjslkfsfkejfsl.GetAll();
            foreach (var item in menus)
            {
                var _list = list.Where(s => s.ParentId == item.value).Select(s => new MenuCrealist
                {
                    value = s.MenuId,
                    label= s.MenuName,
                }).ToList();
                item.children.AddRange(_list);
                GetNodesList(_list);
            }
        }

        public int Add(Menu menu)
        {
            var list = fjslkfsfkejfsl.Add(menu);
            return list;
        }

        public int Del(Menu menu)
        {
            return fjslkfsfkejfsl.Del(menu);

        }
        public int Edit(Menu menu)
        {
            return fjslkfsfkejfsl.Edit(menu);
        }
    }
}

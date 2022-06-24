using ClassLibraryEF;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RbacRepository
{
    public class Repository: Irepository
    {
        public Repository(MyDbContext mydb)
        {
            db = mydb;
        }

        public MyDbContext db { get; }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="meun"></param>
        /// <returns></returns>
        public int Add(Menu meun)
        {
            var list = db.Menu.Add(meun);
            return db.SaveChanges();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Del(Menu menu)
        {
            var list = db.Menu.ToList();
            list = list.Where(s => s.ParentId == menu.MenuId).ToList();
            if (list.Count > 0)
            {
                var lst = db.Menu.Find(menu.MenuId);

                db.Menu.RemoveRange(list);
                db.Menu.Remove(lst);
                return db.SaveChanges();

            }
            else
            {
                var lst = db.Menu.Find(menu.MenuId);
                db.Menu.Remove(lst);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public int Edit(Menu menu)
        {
            db.Entry(menu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges();
        }

        /// <summary>
        /// 获取菜单所有信息
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetAll()
        {
            return db.Menu.ToList();
        }

    }
}

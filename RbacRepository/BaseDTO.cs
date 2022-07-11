using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEF;

namespace RbacRepository
{
    public abstract class BaseDTO<T, TKey> : IBaseDTO<T, TKey>
        where T : class
        where TKey : struct
    {
        protected MyDbContext db;
        public virtual int Add(T list)
        {
            db.Set<T>().Add(list);
            return db.SaveChanges();
        }

        public virtual int Add(List<T> list)
        {
            db.Set<T>().AddRange(list);
            return db.SaveChanges();
        }

        public virtual int Del(TKey k)
        {
            var list = db.Set<T>().Find(k);
            db.Remove(list);
            return db.SaveChanges();
        }
        public virtual int Del(Expression<Func<T, bool>> predicate)
        {
            var entity = db.Set<T>().Where(predicate).ToList();
            db.RemoveRange(entity);
            return db.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return db.Set<T>().Find(id);
        }
        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate).FirstOrDefault();
        }

        public virtual List<T> GetAll()
        {
            var list = db.Set<T>().AsQueryable();
            return list.ToList();
        }

        public virtual int Upd(T t)
        {
            db.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}

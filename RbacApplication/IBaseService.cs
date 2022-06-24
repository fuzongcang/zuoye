using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication
{
    public interface IBaseService<T,TDto>
        where T : class,new()
        where TDto : class,new()
    {
        int Add(TDto dto);
        int Update(TDto dto);
        int Delete(int id);
        TDto GetById(int id);
        List<TDto> GetAll();
    }
}

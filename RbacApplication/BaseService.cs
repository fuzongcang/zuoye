using AutoMapper;
using RbacRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication
{
    public class BaseService<T,TDto>:IBaseService<T,TDto>
        where T : class,new()
        where TDto : class,new()
    {
        private readonly IBaseDTO<T, int> baseService;
        private readonly IMapper mapper;

        public BaseService(IBaseDTO<T, int> baseService, IMapper mapper)
        {
            this.baseService = baseService;
            this.mapper = mapper;
        }

        public int Add(TDto dto)
        {
            return baseService.Add(mapper.Map<T>(dto));
        }

        public int Delete(int id)
        {
            return baseService.Del(id);
        }

        public  virtual List<TDto> GetAll()
        {
            return mapper.Map<List<TDto>>(baseService.GetAll());
        }

        public TDto GetById(int id)
        {
            return mapper.Map<TDto>(baseService.Get(id));
        }

        public int Update(TDto dto)
        {
            return baseService.Upd(mapper.Map<T>(dto));
        }
    }
}

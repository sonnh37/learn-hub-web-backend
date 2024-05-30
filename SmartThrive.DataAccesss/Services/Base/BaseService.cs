using AutoMapper;
using SmartThrive.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services.Base
{
    public class BaseService<TModel, TEntity> : IBaseService<TModel>
                                                where TModel : class
                                                where TEntity : class
    {
        private readonly IMapper mapper;
        private readonly IBaseRepository<TEntity> baseRepository;

        public BaseService(IMapper _mapper, IBaseRepository<TEntity> _baseRepository)
        {
            mapper = _mapper;
            baseRepository = _baseRepository;
        }


        public async Task<IList<TModel>> GetAll()
        {
            try
            {
                var list = await baseRepository.GetAll();
                return mapper.Map<IList<TModel>>(list); 
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Add(TModel model)
        {
            throw new NotImplementedException();

        }

        public async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        

        public async Task<bool> Update(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}

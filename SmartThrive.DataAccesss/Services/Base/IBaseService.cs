using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services.Base
{
    public interface IBaseService<TModel> where TModel : class
    {
        Task<IList<TModel>> GetAll();
        Task<TModel> GetById(Guid id);
        Task<bool> Add(TModel model);
        Task<bool> Delete(Guid id);
        Task<bool> Update(TModel model);
    }
}

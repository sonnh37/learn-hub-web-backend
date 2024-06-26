using SWD.SmartThrive.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.Services.Services.Interface
{
    public interface IProviderService
    {
        public Task<bool> Add(ProviderModel model);
        public Task<bool> Delete(ProviderModel model);
        public Task<bool> Update(ProviderModel model);
        public Task<List<ProviderModel>> GetAllPaginationWithOrder(int pageNumber, int pageSize, string orderBy);
        public Task<ProviderModel> GetById(Guid id);

    }
}

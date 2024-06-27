using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SWD.SmartThrive.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.Services.Services.Interface
{
    public interface ICategoryService
    {
        Task<bool> Add(CategoryModel model);
        Task<bool> Update(CategoryModel model);
        Task<bool> Delete(CategoryModel model);
        Task<List<CategoryModel>> GetAll();
        Task<List<CategoryModel>> GetAllPaginationWithOrder(int pageNumber, int pageSize, string orderBy);
        Task<CategoryModel> GetById(Guid id);
        Task<(List<CategoryModel>?, long)> Search(CategoryModel model, int pageNumber, int pageSize, string orderBy);
        Task<long> GetTotalCount();
    }
}

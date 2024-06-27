using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using System.Linq.Expressions;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(STDbContext context) : base(context)
        {
        }

        public IQueryable<Category> GetQueryablePaginationWithOrderBy(string orderBy)
        {
            // Sắp xếp trước 
            var queryable = base.GetQueryable();

            if (queryable.Any())
            {
                switch (orderBy.ToLower())
                {
                    case "categoryname":
                        queryable = queryable.OrderBy(o => o.CategoryName);
                        break;
                    default:
                        queryable = queryable.OrderBy(o => o.Id);
                        break;
                }
            }
            return queryable;
        }

        public async Task<List<Category>> GetAllPaginationWithOrder(int pageNumber, int pageSize, string orderBy)
        {
            var queryable = this.GetQueryablePaginationWithOrderBy(orderBy);

            queryable = GetQueryablePagination(queryable, pageNumber, pageSize);

            return await queryable.ToListAsync();
        }

        public async Task<(List<Category>, long)> Search(Category category, int pageNumber, int pageSize, string orderBy)
        {
            var queryable = this.GetQueryablePaginationWithOrderBy(orderBy);

            // Điều kiện lọc từng bước
            if (queryable.Any())
            {
                if (!string.IsNullOrEmpty(category.CategoryName))
                {
                    queryable = queryable.Where(m => m.CategoryName.ToLower().Trim().StartsWith(category.CategoryName.ToLower().Trim()));
                }
            }

            var totalOrigin = queryable.Count();

            // Lọc theo trang
            queryable = GetQueryablePagination(queryable, pageNumber, pageSize);

            var categories = await queryable.ToListAsync();

            return (categories, totalOrigin);
        }
    }
}

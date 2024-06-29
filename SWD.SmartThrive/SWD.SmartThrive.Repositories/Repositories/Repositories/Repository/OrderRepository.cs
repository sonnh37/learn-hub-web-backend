using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Model;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly STDbContext _context;

        public OrderRepository(STDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrder(int pageNumber, int pageSize, string orderBy)
        {
            var queryable = this.GetQueryablePaginationWithOrderBy(orderBy);

            // Lọc theo trang
            queryable = GetQueryablePagination(queryable, pageNumber, pageSize);

            return await queryable.ToListAsync();
        }

        public async Task<(List<Order>, long)> GetAllOrderSearch(Order Order, int pageNumber, int pageSize, string orderBy)
        {
            var queryable = this.GetQueryablePaginationWithOrderBy(orderBy);

            // Điều kiện lọc từng bước
            if (queryable.Any())
            {
                //    if (!string.IsNullOrEmpty(Course.CourseName))
                //    {
                //        queryable = queryable.Where(m => m.CourseName.ToLower().Trim() == Course.CourseName.ToLower().Trim());
                //    }

                //    if (!string.IsNullOrEmpty(Course.Description))
                //    {
                //        queryable = queryable.Where(m => m.Description.ToLower().Trim().Contains(Course.Description.ToLower().Trim()));
                //    }

                //    if (!decimal.IsNullOrEmpty(Course.Price))
                //    {
                //        queryable = queryable.Where(m => m.Price == Course.Price);
                //    }

                //    if (user.DOB.HasValue)
                //    {
                //        queryable = queryable.Where(m => m.DOB.Value.Date == user.DOB.Value.Date);
                //    }

                if (Order.Status.HasValue)
                {
                    queryable = queryable.Where(m => m.Status == Order.Status);
                }
                if (Order.PackageId != Guid.Empty && Order.PackageId != null)
                {
                    queryable = queryable.Where(m => m.PackageId == Order.PackageId);
                }

            }
                var totalOrigin = queryable.Count();

                // Lọc theo trang
                queryable = GetQueryablePagination(queryable, pageNumber, pageSize);

                var orders = await queryable.ToListAsync();

                return (orders, totalOrigin);
            
        }

        //public Task<List<Order>> SearchOrder(string name)
        //{
        //    var queryable = base.GetQueryable(x => x..StartsWith(name) || x.Id.Equals(name));

        //    if (queryable.Any())
        //    {
        //        queryable = queryable.Where(x => !x.IsDeleted);
        //    }

        //    if (queryable.Any())
        //    {
        //        var results = await queryable.Include(x => x.Provider).ToListAsync();

        //        return results;
        //    }

        //    return null;
        //}
        public IQueryable<Order> GetQueryablePaginationWithOrderBy(string orderBy)
        {
            // Sắp xếp trước 
            var queryable = base.GetQueryable();

            if (queryable.Any())
            {
                switch (orderBy.ToLower())
                {
                    case "totalprice":
                        queryable = queryable.OrderBy(o => o.TotalPrice);
                        break;
                    case "amount":
                        queryable = queryable.OrderBy(o => o.Amount);
                        break;

                    default:
                        queryable = queryable.OrderBy(o => o.Id);
                        break;
                }
            }

            return queryable;
        }
    }
}

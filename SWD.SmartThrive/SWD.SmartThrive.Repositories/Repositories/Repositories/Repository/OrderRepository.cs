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

        public async Task<List<Order>> GetAllOrder(int pageNumber, int pageSize, string sortField, int sortOrder)
        {
            var queryable = base.ApplySort(sortField, sortOrder);

            // Lọc theo trang
            queryable = GetQueryablePagination(queryable, pageNumber, pageSize);

            return await queryable.ToListAsync();
        }

        public async Task<(List<Order>, long)> GetAllOrderSearch(Order Order, int pageNumber, int pageSize, string sortField, int sortOrder)
        {
            var queryable = base.ApplySort(sortField, sortOrder);

            // Điều kiện lọc từng bước
            if (queryable.Any())
            {
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
    }
}

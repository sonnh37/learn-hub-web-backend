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

        public async Task<List<Order>> GetAllOrderByStudent(Guid id)
        {
            //var a = from c in _context.Orders
            //        join t in _context.Packages on c.PackageId equals t.Id
            //        join s in _context.Students on t.StudentId equals s.Id
            //        select new OrderByStudent
            //        {
            //            Id = c.Id,
            //            PackageId = c.Id,
            //            PackageName = t.PackageName,
            //            PaymentMethod = c.PaymentMethod,
            //            Amount = c.Amount,
            //            TotalPrice = c.TotalPrice,
            //            Description = c.Description,
            //            Status = c.Status,
            //            CreatedBy = c.CreatedBy,
            //            CreatedDate = c.CreatedDate,
            //            LastUpdatedDate = c.LastUpdatedDate,
            //            LastUpdatedBy = c.LastUpdatedBy,
            //            IsDeleted = c.IsDeleted
            //        };
            //return await a.Where(x => x.StudentId == id).ToListAsync();

            var queryable = base.GetQueryable(x => x.Package!.StudentId == id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var results = await queryable.Include(x => x.Package)
                    .ToListAsync();

                return results;
            }

            return null;
        }

        public async Task<List<Order>> GetAllOrder()
        {
            var queryable = await GetAll();

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var results = await queryable.ToListAsync();

                return results;
            }

            return null;
        }

        public async Task<Order> GetOrder(Guid id)
        {
            var queryable = await base.GetById(id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();

                return entity;
            }

            return null;
        }

        public async Task<List<Order>> SearchOrderByIdOrName(string id)
        {

            var queryable = base.GetQueryable(x => x.Id.Equals(id));

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }


            //if (queryable.Any())
            //{
            //    var results = await queryable.Include(x => x.Provider).ToListAsync();

            //    return results;
            //}

            return queryable.ToList();
        }
    }
}

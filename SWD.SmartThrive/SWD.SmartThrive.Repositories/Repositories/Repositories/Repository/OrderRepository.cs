using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Table;
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

        public async Task<bool> AddOrder(Order order)
        {
            var entity = await base.GetById(order.Id);

            if (entity != null)
            {
                return false;
            }

            base.Add(order);
            _context.SaveChanges();

            return true;
        }
        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            var a = await GetAll();
            return a;
        }

        public async Task<IEnumerable<OrderByStudent>> GetAllOrdersByStudent(Guid id)
        {
            var a = from c in _context.Orders
                    join t in _context.Packages on c.PackageId equals t.Id
                    join s in _context.Students on t.StudentId equals s.Id
                    select new OrderByStudent
                    {
                        Id = c.Id,
                        PackageId = c.Id,
                        PackageName = t.PackageName,
                        PaymentMethod = c.PaymentMethod,
                        Amount = c.Amount,
                        TotalPrice = c.TotalPrice,
                        Description = c.Description,
                        Status = c.Status,
                        CreateBy = c.CreatedBy,
                        CreateDate = c.CreatedDate,
                        LastUpdatedDate = c.LastUpdatedDate,
                        LastUpdatedBy = c.LastUpdatedBy,
                        IsDeleted = c.IsDeleted
                    };
            return await a.Where(x => x.StudentId == id).ToListAsync();
        }

        public async Task<Order> GetOrder(Guid id)
        {
            var order = await GetById(id);

            return order;
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            // Update
            var entity = await base.GetById(order.Id);

            if (entity == null)
            {
                return false;
            }

            base.Update(entity);
            _context.SaveChanges();

            return true;
        }
    }
}

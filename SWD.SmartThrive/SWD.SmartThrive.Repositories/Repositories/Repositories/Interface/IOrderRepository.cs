using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Model;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface IOrderRepository : IBaseRepository
    {
        public Task<bool> AddOrder(Order order);

        public Task<bool> UpdateOrder(Order order);

        public Task<Order> GetOrder(Guid id);

        public Task<List<OrderByStudent>> GetAllOrderByStudent(Guid id);

        public Task<List<Order>> GetAllOrder();
    }
}

using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Model;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface IOrderRepository
    {
        public Task<bool> AddOrder(Order order);
        public Task<bool> UpdateOrder(Order order);


        public Task<Order> GetOrder(Guid id);

        public Task<IEnumerable<OrderByStudent>> GetAllOrdersByStudent(Guid id);

        public Task<IEnumerable<Order>> GetAllOrder();
    }
}

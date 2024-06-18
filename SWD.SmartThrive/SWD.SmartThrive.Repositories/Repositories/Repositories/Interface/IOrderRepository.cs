using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Model;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Task<Order> GetOrder(Guid id);

        public Task<List<Order>> GetAllOrderByStudent(Guid id);

        public Task<List<Order>> GetAllOrder();

        public Task<List<Order>> SearchOrderByIdOrName(string id);
    }
}

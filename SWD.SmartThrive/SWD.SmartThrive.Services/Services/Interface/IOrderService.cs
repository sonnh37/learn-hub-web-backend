using SWD.SmartThrive.Repositories.Repositories.Repositories.Model;
using SWD.SmartThrive.Services.Model;

namespace SWD.SmartThrive.Services.Services.Interface
{
    public interface IOrderService
    {
        public Task<bool> AddOrder(OrderModel order);

        public Task<bool> UpdateOrder(OrderModel order);

        public Task<bool> DeleteOrder(Guid id);

        public Task<OrderModel> GetOrder(Guid id);

        public Task<List<OrderModel>> GetAllOrderByStudent(Guid id);

        public Task<List<OrderModel>> GetAllOrder();

        public Task<List<OrderModel>> SearchOrderById(string id);

    }
}

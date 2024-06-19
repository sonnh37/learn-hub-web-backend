using SWD.SmartThrive.Repositories.Repositories.Repositories.Model;
using SWD.SmartThrive.Services.Model;

namespace SWD.SmartThrive.Services.Services.Interface
{
    public interface IOrderService
    {
        Task<bool> AddOrder(OrderModel OrderModel);
        Task<bool> DeleteOrder(Guid id);
        Task<List<OrderModel>> GetAllOrder();
        Task<OrderModel> GetOrder(Guid id);
        Task<bool> UpdateOrder(OrderModel OrderModel);
    }
}

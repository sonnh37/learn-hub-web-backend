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

        public Task<List<OrderModel>?> GetAllPagination(int pageNumber, int pageSize, string sortField, int sortOrder);

        public Task<(List<OrderModel>?, long)> GetAllOrderSearch(OrderModel ordermodel, int pageNumber, int pageSize, string sortField, int sortOrder);

        public Task<long> GetTotalCount();

    }
}

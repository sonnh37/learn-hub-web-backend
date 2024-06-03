using SmartThrive.DataAccesss.Model.RequestModel;
using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services.Interface
{
    public interface IOrderService
    {
        public Task<bool> AddOrder(OrderRequest order);
        public Task<bool> UpdateOrder(OrderRequest order);

        public Task<bool> DeleteOrder(Guid id);

        public Task<OrderRequest> GetOrder(Guid id);

        public Task<IEnumerable<OrderRequest>> GetAllOrdersByStudent(Guid id);

        public Task<IEnumerable<OrderRequest>> GetAllOrder();

    }
}

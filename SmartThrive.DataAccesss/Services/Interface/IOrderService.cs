using ST.Entities.Data.Table;
using SWD.DataAccesss.Model;
using SWD.Entities.Repositories.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services.Interface
{
    public interface IOrderService
    {
        public Task<bool> AddOrder(OrderModel order);
        public Task<bool> UpdateOrder(OrderModel order);

        public Task<bool> DeleteOrder(Guid id);

        public Task<OrderModel> GetOrder(Guid id);

        public Task<IEnumerable<OrderByStudent>> GetAllOrdersByStudent(Guid id);

        public Task<IEnumerable<OrderModel>> GetAllOrder();

    }
}

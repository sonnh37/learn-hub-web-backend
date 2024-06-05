using ST.Entities.Data.Table;
using SWD.Entities.Repositories.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.Entities.Repositories.Repositories.Interface
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

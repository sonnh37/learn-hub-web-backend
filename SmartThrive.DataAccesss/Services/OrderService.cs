using AutoMapper;
using SmartThrive.DataAccesss.Model.RequestModel;
using SmartThrive.DataAccesss.Repositories.Repositories.Interface;
using SmartThrive.DataAccesss.Services.Interface;
using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository , IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public async Task<bool> AddOrder(OrderRequest order)
        {
           var s = _mapper.Map<Order>(order);
            return await _repo.AddOrder(s);
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            return await _repo.DeleteOrder(id);
        }

        public async Task<IEnumerable<OrderRequest>> GetAllOrder()
        {
           var s = await _repo.GetAllOrder();
            return _mapper.Map<IEnumerable<OrderRequest>>(s);


        }

        public async Task<IEnumerable<OrderRequest>> GetAllOrdersByStudent(Guid id)
        {
            var s = await _repo.GetAllOrdersByStudent(id);

            return _mapper.Map<IEnumerable<OrderRequest>>(s);
        }

        public async Task<OrderRequest> GetOrder(Guid id)
        {
            var s = await _repo.GetOrder(id);

            return _mapper.Map<OrderRequest>(s);
        }

        public async Task<bool> UpdateOrder(OrderRequest order)
        {
           return await _repo.UpdateOrder(_mapper.Map<Order>(order));
        }
    }
}

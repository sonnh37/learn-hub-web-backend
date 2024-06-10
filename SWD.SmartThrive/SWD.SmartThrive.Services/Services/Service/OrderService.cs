using AutoMapper;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Model;
using SWD.SmartThrive.Repositories.Repositories.UnitOfWork.Interface;
using SWD.SmartThrive.Services.Base;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;

namespace SWD.SmartThrive.Services.Services.Service
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
            _repository = unitOfWork.OrderRepository;
        }

        public async Task<bool> AddOrder(OrderModel orderModel)
        {
            var order = _mapper.Map<Order>(orderModel);
            return await _repository.AddOrder(order);
        }

        public async Task<bool> UpdateOrder(OrderModel orderModel)
        {
            var order = _mapper.Map<Order>(orderModel);
            return await _repository.UpdateOrder(order);
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            var order = await _repository.GetOrder(id);
            if (order != null)
            {
                order.IsDeleted = true;
                var isOrder = await _repository.UpdateOrder(order);

                if (isOrder)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<List<OrderModel>> GetAllOrder()
        {
            var orders = await _repository.GetAllOrder();

            if (orders == null)
            {
                return null;
            }

            return _mapper.Map<List<OrderModel>>(orders);
        }

        public async Task<List<OrderByStudent>> GetAllOrderByStudent(Guid id)
        {

            var orders = await _repository.GetAllOrderByStudent(id);

            if (orders == null)
            {
                return null;
            }

            return _mapper.Map<List<OrderByStudent>>(orders);
        }

        public async Task<OrderModel> GetOrder(Guid id)
        {
            var order = await _repository.GetOrder(id);

            if (order == null)
            {
                return null;
            }

            return _mapper.Map<OrderModel>(order);
        }
    }
}

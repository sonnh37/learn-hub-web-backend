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
            var order = await _repository.GetOrder(orderModel.Id);

            if (order != null)
            {
                return false;
            }

            var _order = _mapper.Map<Order>(orderModel);
            _order.Id = Guid.NewGuid();
            _repository.Add(_order);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
        }

        public async Task<bool> UpdateOrder(OrderModel orderModel)
        {
            var order = await _repository.GetOrder(orderModel.Id);

            if (order == null)
            {
                return false;
            }

            _mapper.Map(orderModel, order);
            _repository.Update(order);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            var order = await _repository.GetOrder(id);

            if (order == null)
            {
                return false;
            }

            _repository.Delete(order);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
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

        public async Task<List<OrderModel>> GetAllOrderByStudent(Guid id)
        {

            var orders = await _repository.GetAllOrderByStudent(id);

            if (orders == null)
            {
                return null;
            }

            return _mapper.Map<List<OrderModel>>(orders);
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

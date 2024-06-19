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

        public async Task<bool> AddOrder(OrderModel OrderModel)
        {
            var Order = _mapper.Map<Order>(OrderModel);
            return await _repository.Add(Order);
        }

        public async Task<bool> UpdateOrder(OrderModel OrderModel)
        {
            var entity = await _repository.GetById(OrderModel.Id);
            if (entity == null)
            {
                return false;
            }

            var Order = _mapper.Map<Order>(OrderModel);
            return await _repository.Update(Order);
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return false;
            }

            var Order = _mapper.Map<Order>(entity);
            return await _repository.Delete(Order);
        }

        public async Task<List<OrderModel>> GetAllOrder()
        {
            var Orders = await _repository.GetAll();

            if (Orders == null)
            {
                return null;
            }

            return _mapper.Map<List<OrderModel>>(Orders);
        }

        public async Task<OrderModel> GetOrder(Guid id)
        {
            var Order = await _repository.GetById(id);

            if (Order == null)
            {
                return null;
            }

            return _mapper.Map<OrderModel>(Order);
        }
    }
}

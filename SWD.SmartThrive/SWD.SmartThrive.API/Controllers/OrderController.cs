    using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SWD.SmartThrive.Services.Services.Interface;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.API.Tool.Constant;
using SWD.SmartThrive.API.ResponseModel;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Model;
using Microsoft.AspNetCore.Authorization;

namespace SWD.SmartThrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrderController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await _service.GetAllOrder();

                return orders switch
                {
                    null => Ok(new ItemListResponse<OrderModel>(ConstantMessage.Fail, null)),
                    not null => Ok(new ItemListResponse<OrderModel>(ConstantMessage.Success, orders))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id is empty");
                }
                var orderModel = await _service.GetOrder(id);

                return orderModel switch
                {
                    null => Ok(new ItemResponse<OrderModel>(ConstantMessage.NotFound)),
                    not null => Ok(new ItemResponse<OrderModel>(ConstantMessage.Success, orderModel))
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder(OrderRequest order)
        {
            try
            {
                var isOrder = await _service.AddOrder(_mapper.Map<OrderModel>(order));

                return isOrder switch
                {
                    true => Ok(new BaseResponse(isOrder, ConstantMessage.Success)),
                    _ => Ok(new BaseResponse(isOrder, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var isOrder = await _service.DeleteOrder(id);

                    return isOrder switch
                    {
                        true => Ok(new BaseResponse(isOrder, ConstantMessage.Success)),
                        _ => Ok(new BaseResponse(isOrder, ConstantMessage.Fail))
                    };
                }
                else
                {
                    return BadRequest("It's not empty");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(OrderRequest order)
        {
            try
            {
                var orderModel = _mapper.Map<OrderModel>(order);

                var isOrder = await _service.UpdateOrder(orderModel);

                return isOrder switch
                {
                    true => Ok(new BaseResponse(isOrder, ConstantMessage.Success)),
                    _ => Ok(new BaseResponse(isOrder, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

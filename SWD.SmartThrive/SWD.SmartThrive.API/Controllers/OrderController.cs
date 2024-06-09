using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SWD.SmartThrive.Services.Services.Interface;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.API.Tool.Response;
using SWD.SmartThrive.API.Tool.Constant;

namespace SWD.SmartThrive.API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrderController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get-order")]
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
                    not null => Ok(AppResponse.GetResponseResult<OrderModel>(
                        orderModel,
                        ConstantMessage.NotFound,
                        ConstantHttpStatus.NOT_FOUND)),
                    null => Ok(AppResponse.GetResponseResult<OrderModel>(
                        orderModel,
                        ConstantMessage.Success))
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add-new-order")]
        public async Task<IActionResult> AddOrder(OrderRequest order)
        {
            try
            {
                var isOrder = await _service.AddOrder(_mapper.Map<OrderModel>(order));

                return isOrder switch
                {
                    true => Ok(AppResponse.GetResponseBool(isOrder, ConstantMessage.Success)),
                    _ => Ok(AppResponse.GetResponseBool(isOrder, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("delete-order")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var isOrder = await _service.DeleteOrder(id);

                    return isOrder switch
                    {
                        true => Ok(AppResponse.GetResponseBool(isOrder, ConstantMessage.Success)),
                        _ => Ok(AppResponse.GetResponseBool(isOrder, ConstantMessage.Fail))
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

        [HttpPut("update-order")]
        public async Task<IActionResult> Update(OrderRequest order)
        {
            try
            {
                var orderModel = _mapper.Map<OrderModel>(order);

                var isOrder = await _service.UpdateOrder(orderModel);

                return isOrder switch
                {
                    true => Ok(AppResponse.GetResponseBool(isOrder, ConstantMessage.Success)),
                    _ => Ok(AppResponse.GetResponseBool(isOrder, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-order-by-student")]
        public async Task<IActionResult> GetAllPackageByStudent(Guid studentid)
        {
            try
            {
                if (studentid == Guid.Empty)
                {
                    return BadRequest("StudentId is empty");
                }

                var orderModels = await _service.GetAllOrdersByStudent(studentid);

                return orderModels switch
                {
                    not null => Ok(AppResponse.GetResponseResultList(orderModels, ConstantMessage.Success)),
                    null => Ok(AppResponse.GetResponseResultList(orderModels, ConstantMessage.NotFound, ConstantHttpStatus.NOT_FOUND))
                };

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

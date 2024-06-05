using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SWD.SmartThrive.API.ResponseModel;
using SWD.SmartThrive.Services.Services.Interface;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.API.RequestModel;

namespace Smart_Thrive.Controllers
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
                var s = await _service.GetOrder(id);
                if (s == null)
                {
                    return NotFound();
                }
                return Ok(s);

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
                var s = await _service.AddOrder(_mapper.Map<OrderModel>(order));
                if (s)
                {
                    return Ok(new BaseReponse()
                    {
                        Code = 200,
                        Data = s,
                        Message = "Succesfuly"

                    });
                }
                return BadRequest(s);

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
                    var sss = await _service.DeleteOrder(id);
                    if (sss)
                    {
                        return Ok("Succesfuly");
                    }
                    else
                    {
                        return BadRequest("Id is not exist or wrong");
                    }
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
                var s = _mapper.Map<OrderModel>(order);

                //      var exist = _service.GetOrder(order.Id);

                //      if (exist != null)
                //      {
                var sss = await _service.UpdateOrder(s);
                if (sss)
                {
                    return Ok(new BaseReponse()
                    {
                        Code = 200,
                        Data = sss,
                        Message = "Succesfuly"

                    });
                }
                else
                {
                    return BadRequest("Faild");
                }
                //         }
                //         else
                //        {
                //return BadRequest("It's not exist");
                //        }
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


                /// nho check xem id co trong database khong o student
                if (studentid == Guid.Empty)
                {
                    return BadRequest("StudentId is empty");
                }
                var s = await _service.GetAllOrdersByStudent(studentid);
                if (s == null)
                {
                    return BadRequest("Empty");
                }
                return Ok(new BaseReponse()
                {
                    Code = 200,
                    Data = s,
                    Message = "Succesfuly"

                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}

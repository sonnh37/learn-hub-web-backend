using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SWD.SmartThrive.Services.Services.Interface;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.API.Tool.Constant;
using SWD.SmartThrive.API.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using SWD.SmartThrive.Services.Services.Service;

namespace SWD.SmartThrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _service;
        private readonly IMapper _mapper;

        public SessionController(ISessionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var sessions = await _service.GetAllSession();

                return sessions switch
                {
                    null => Ok(new ItemListResponse<SessionModel>(ConstantMessage.Fail, null)),
                    not null => Ok(new ItemListResponse<SessionModel>(ConstantMessage.Success, sessions))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetSession(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id is empty");
                }
                var sessionModel = await _service.GetSession(id);

                return sessionModel switch
                {
                    null => Ok(new ItemResponse<SessionModel>(ConstantMessage.NotFound)),
                    not null => Ok(new ItemResponse<SessionModel>(ConstantMessage.Success, sessionModel))
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSession(SessionRequest session)
        {
            try
            {
                var isSession = await _service.AddSession(_mapper.Map<SessionModel>(session));

                return isSession switch
                {
                    true => Ok(new BaseResponse(isSession, ConstantMessage.Success)),
                    _ => Ok(new BaseResponse(isSession, ConstantMessage.Fail))
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
                    var isSession = await _service.DeleteSession(id);

                    return isSession switch
                    {
                        true => Ok(new BaseResponse(isSession, ConstantMessage.Success)),
                        _ => Ok(new BaseResponse(isSession, ConstantMessage.Fail))
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
        public async Task<IActionResult> Update(SessionRequest session)
        {
            try
            {
                var sessionModel = _mapper.Map<SessionModel>(session);

                var isSession = await _service.UpdateSession(sessionModel);

                return isSession switch
                {
                    true => Ok(new BaseResponse(isSession, ConstantMessage.Success)),
                    _ => Ok(new BaseResponse(isSession, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

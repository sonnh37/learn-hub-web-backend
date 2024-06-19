using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SWD.SmartThrive.Services.Services.Interface;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.API.Tool.Constant;
using SWD.SmartThrive.API.ResponseModel;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("get-session")]
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
                    not null => Ok(new BaseReponse<SessionModel>(sessionModel, ConstantMessage.Success)),
                    null => Ok(new BaseReponse<SessionModel>(
                        null,
                        ConstantMessage.NotFound,
                        ConstantHttpStatus.NOT_FOUND))
                    
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add-new-session")]
        public async Task<IActionResult> AddSession(SessionRequest session)
        {
            try
            {
                var isSession = await _service.AddSession(_mapper.Map<SessionModel>(session));

                return isSession switch
                {
                    true => Ok(new BaseReponseBool(isSession, ConstantMessage.Success)),
                    _ => Ok(new BaseReponseBool(isSession, ConstantMessage.Fail, ConstantHttpStatus.NOT_FOUND))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("delete-session")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var isSession = await _service.DeleteSession(id);

                    return isSession switch
                    {
                        true => Ok(new BaseReponseBool(isSession, ConstantMessage.Success)),
                        _ => Ok(new BaseReponseBool(isSession, ConstantMessage.Fail, ConstantHttpStatus.NOT_FOUND))
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

        [HttpPut("update-session")]
        public async Task<IActionResult> Update(SessionRequest session)
        {
            try
            {
                var sessionModel = _mapper.Map<SessionModel>(session);

                var isSession = await _service.UpdateSession(sessionModel);

                return isSession switch
                {
                    true => Ok(new BaseReponseBool(isSession, ConstantMessage.Success)),
                    _ => Ok(new BaseReponseBool(isSession, ConstantMessage.Fail, ConstantHttpStatus.NOT_FOUND))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("get-all-session-by-course")]
        //public async Task<IActionResult> GetAllPackageByStudent(Guid studentid)
        //{
        //    try
        //    {
        //        if (studentid == Guid.Empty)
        //        {
        //            return BadRequest("StudentId is empty");
        //        }

        //        var sessionModels = await _service.GetAllSessionByCourse(studentid);

        //        return sessionModels switch
        //        {
        //            not null => Ok(new BaseReponseList<SessionModel>(sessionModels, ConstantMessage.Success)),
        //            null => Ok(new BaseReponseList<SessionModel>(null, ConstantMessage.NotFound, ConstantHttpStatus.NOT_FOUND))
        //        };

        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}

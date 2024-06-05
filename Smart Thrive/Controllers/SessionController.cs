using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Thrive.ResponseModel;
using SmartThrive.DataAccesss.Model.RequestModel;
using SmartThrive.DataAccesss.Services.Interface;
using SWD.DataAccesss.Model;

namespace Smart_Thrive.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public SessionController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }



        [HttpPost]
        public async Task<IActionResult> Add(SessionRequest session)
        {
            try
            {
                var ss = _mapper.Map<SessionModel>(session);
                var s = await _sessionService.AddSession(ss);
                if (s)
                {
                    return Ok(s);
                }
                else
                {
                    return BadRequest("Hu r cuu t");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetSessionById(Guid id)
        {
            try
            {
                var s = _sessionService.GetSession(id);
                if (s != null)
                {
                    return Ok(s);
                }
                else
                {
                    return BadRequest("It'not exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(SessionRequest session)
        {
            try
            {
                var s = _mapper.Map<SessionModel>(session);

                var exist = _sessionService.GetSession(s.Id);

                if (exist != null)
                {
                    var sss = await _sessionService.UpdateSession(s);
                    if (sss)
                    {
                        return Ok("Succesfuly");
                    }
                    else
                    {
                        return BadRequest("Faild");
                    }
                }
                else
                {
                    return BadRequest("It's not exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("abc")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {


                var exist = _sessionService.GetSession(id);

                if (exist != null)
                {
                    var sss = await _sessionService.DeleteSession(id);
                    if (sss)
                    {
                        return Ok("Succesfuly");
                    }
                    else
                    {
                        return BadRequest("Faild");
                    }
                }
                else
                {
                    return BadRequest("It's not exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-session-by-course")]
        public async Task<IActionResult> GetAllSessionByCourse(Guid CourseId)
        {
            try
            {


                /// nho check xem id co trong database khong o student
                if (CourseId == Guid.Empty)
                {
                    return BadRequest("CourseId is empty");
                }
                var s = await _sessionService.GetAllSessionByCourse(CourseId);
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

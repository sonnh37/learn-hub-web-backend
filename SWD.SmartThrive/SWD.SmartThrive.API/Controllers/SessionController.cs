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
            var ss = _mapper.Map<SessionModel>(session);
            var s = await _sessionService.AddSession(ss);

            return Ok(s);
        }

        [HttpGet]
        public async Task<IActionResult> GetSessionById(Guid id)
        {
            var s = await _sessionService.GetSession(id);

            return Ok(s);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SessionRequest session)
        {
            var s = _mapper.Map<SessionModel>(session);
            var exist = _sessionService.GetSession(s.Id);
            var sss = await _sessionService.UpdateSession(s);

            return Ok(sss);
        }

        [HttpPut("abc")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var exist = _sessionService.GetSession(id);
            var sss = await _sessionService.DeleteSession(id);

            return Ok(sss);
        }

        [HttpGet("get-all-session-by-course")]
        public async Task<IActionResult> GetAllSessionByCourse(Guid CourseId)
        {
            try
            {
                // ko tra BadRequest, 

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

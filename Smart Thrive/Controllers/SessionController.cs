using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Add(SessionRequest session )
        {
            try
            {
                var ss = _mapper.Map<SessionModel>(session);
                var s = await _sessionService.AddSession(ss);
                if (s)
                {
                    return Ok(s);
                }else
                {
                    return BadRequest("Hu r cuu t");
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.API.ResponseModel;
using SWD.SmartThrive.API.Tool.Constant;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;
using System.IdentityModel.Tokens.Jwt;

namespace SWD.SmartThrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get-user")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id is empty");
                }
                var userModel = await _service.GetUser(id);

                return userModel switch
                {
                    null => Ok(new BaseReponse<UserModel>(
                        userModel,
                        ConstantMessage.NotFound,
                        ConstantHttpStatus.NOT_FOUND)),
                    not null => Ok(new BaseReponse<UserModel>(userModel, ConstantMessage.Success))
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add-new-user")]
        public async Task<IActionResult> AddUser(UserRequest user)
        {
            try
            {
                var isUser = await _service.AddUser(_mapper.Map<UserModel>(user));

                return isUser switch
                {
                    true => Ok(new BaseReponseBool(isUser, ConstantMessage.Success)),
                    _ => Ok(new BaseReponseBool(isUser, ConstantMessage.Fail, ConstantHttpStatus.NOT_FOUND))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("delete-user")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var isUser = await _service.DeleteUser(id);

                    return isUser switch
                    {
                        true => Ok(new BaseReponseBool(isUser, ConstantMessage.Success)),
                        _ => Ok(new BaseReponseBool(isUser, ConstantMessage.Fail, ConstantHttpStatus.NOT_FOUND))
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

        [HttpPut("update-user")]
        public async Task<IActionResult> Update(UserRequest user)
        {
            try
            {
                var userModel = _mapper.Map<UserModel>(user);

                var isUser = await _service.UpdateUser(userModel);

                return isUser switch
                {
                    true => Ok(new BaseReponseBool(isUser, ConstantMessage.Success)),
                    _ => Ok(new BaseReponseBool(isUser, ConstantMessage.Fail, ConstantHttpStatus.NOT_FOUND))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthModel authModel)
        {
            try
            {
                var userModel = await _service.Login(authModel);

                if (userModel == null)
                {
                    return Ok(new LoginResponse<UserModel>(null, null, null, ConstantMessage.Fail, ConstantHttpStatus.NOT_FOUND));
                }

                JwtSecurityToken token = _service.CreateToken(userModel);

                return Ok(new LoginResponse<UserModel>(userModel, new JwtSecurityTokenHandler().WriteToken(token)
                , token.ValidTo.ToString(), ConstantMessage.Success));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        // POST api/<AuthController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel _userModel)
        {
            try
            {
                UserModel userModel = await _service.Register(_userModel);

                return userModel switch
                {
                    null => Ok(new BaseReponse<UserModel>(
                        null,
                        ConstantMessage.NotFound,
                        ConstantHttpStatus.NOT_FOUND)),
                    not null => Ok(new BaseReponse<UserModel>(userModel, ConstantMessage.Success))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

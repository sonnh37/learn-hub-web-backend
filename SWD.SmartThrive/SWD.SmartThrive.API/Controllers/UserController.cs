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

        [HttpPost("get-all-user-search")]
        public async Task<IActionResult> GetAllUserSearch(PaginatedRequest<UserSearchRequest> paginatedRequest)
        {
            try
            {
                var user = _mapper.Map<UserModel>(paginatedRequest.Result);
                var users = await _service.GetAllUserSearch(user, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy);

                return users.Item1 switch
                {
                    null => Ok(new PaginatedResponseList<UserModel>(ConstantMessage.NotFound, users.Item1, users.Item2, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy)),
                    not null => Ok(new PaginatedResponseList<UserModel>(ConstantMessage.Success, users.Item1, users.Item2, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy))
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        [HttpPost("get-all-user")]
        public async Task<IActionResult> GetAllUser(PaginatedRequest paginatedRequest)
        {
            try
            {
                var users = await _service.GetAllUser(paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy);
                long totalOrigin = await _service.GetTotalCount();
                return users switch
                {
                    null => Ok(new PaginatedResponseList<UserModel>(ConstantMessage.NotFound)),
                    not null => Ok(new PaginatedResponseList<UserModel>(ConstantMessage.Success, users, totalOrigin, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy))
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
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
                    null => Ok(new PaginatedResponse<UserModel>(ConstantMessage.NotFound)),
                    not null => Ok(new PaginatedResponse<UserModel>(ConstantMessage.Success, userModel))
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
                    _ => Ok(new BaseReponseBool(isUser, ConstantMessage.Fail))
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
                        _ => Ok(new BaseReponseBool(isUser, ConstantMessage.Fail))
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
                    _ => Ok(new BaseReponseBool(isUser, ConstantMessage.Fail))
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
                    return Ok(new LoginResponse<UserModel>(null, null, null, ConstantMessage.Fail));
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
        public async Task<IActionResult> Register([FromBody] UserRequest userRequest)
        {
            try
            {
                UserModel userModel = await _service.Register(_mapper.Map<UserModel>(userRequest));

                return userModel switch
                {
                    null => Ok(new PaginatedResponse<UserModel>(ConstantMessage.NotFound)),
                    not null => Ok(new PaginatedResponse<UserModel>(ConstantMessage.Success, userModel))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

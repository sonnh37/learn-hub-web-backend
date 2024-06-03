using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartThrive.DataAccess.Repositories.Repositories.Interface;
using SmartThrive.DataAccesss.Model.RequestModel;
using SmartThrive.DataAccesss.Services.Interface;
using ST.Entities.Data.Table;
using ST.Entities.Model;
using System.Net;

namespace Smart_Thrive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

      

        public UserController(IUserService _userService )
        {
            this.userService = _userService;

        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        var users = userService.GetAll();
        //        return Ok(new
        //        {
        //            Status
        //        });
        //    } catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        //public Task<UserModel> GetById(Guid id);
        //public Task<bool> Add(UserModel user);
        //public Task<bool> Update(UserModel user);
        //public Task<bool> Delete(Guid id);
        //public Task<List<UserModel>> GetByRoleId(Guid roleId);
        //public Task<UserModel> GetUserByEmail(string email);
        ////public Task<User> Login(string username, string password);
        //public Task<bool> UpdatePassword(string email, string password);
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            try
            {
                User user = await userService.GetUserById(id);
                return Ok(user);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("create-user")]
        public async Task<IActionResult> AddUser(UserRequest model)
        {
            try
            {
                var newStudent = await userService.AddUser(model);
                //   var student = await _studentService.getStudentByID(model.StudentId);
                //    return student == null ? NotFound() : Ok(student);
                if (newStudent)
                    return Ok( "Add succesfully"
                       
                );
                else return BadRequest("Add failed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

    }
}

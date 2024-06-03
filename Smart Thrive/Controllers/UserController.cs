using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartThrive.DataAccess.Repositories.Repositories.Interface;
using SmartThrive.DataAccesss.Services.Interface;
using ST.Entities.Data.Table;
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
        public async Task<IActionResult> AddUser(User model)
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

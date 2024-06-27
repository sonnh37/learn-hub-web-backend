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
    public class CourseController : Controller
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;

        public CourseController(ICourseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courses = await _service.GetAllCourse();

                return courses switch
                {
                    null => Ok(new ItemListResponse<CourseModel>(ConstantMessage.Fail, null)),
                    not null => Ok(new ItemListResponse<CourseModel>(ConstantMessage.Success, courses))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id is empty");
                }
                var courseModel = await _service.GetCourse(id);

                return courseModel switch
                {
                    null => Ok(new ItemResponse<CourseModel>(ConstantMessage.NotFound)),
                    not null => Ok(new ItemResponse<CourseModel>(ConstantMessage.Success, courseModel))
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCourse(CourseRequest course)
        {
            try
            {
                var isCourse = await _service.AddCourse(_mapper.Map<CourseModel>(course));

                return isCourse switch
                {
                    true => Ok(new BaseResponse(isCourse, ConstantMessage.Success)),
                    _ => Ok(new BaseResponse(isCourse, ConstantMessage.Fail))
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
                    var isCourse = await _service.DeleteCourse(id);

                    return isCourse switch
                    {
                        true => Ok(new BaseResponse(isCourse, ConstantMessage.Success)),
                        _ => Ok(new BaseResponse(isCourse, ConstantMessage.Fail))
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
        public async Task<IActionResult> Update(CourseRequest course)
        {
            try
            {
                var courseModel = _mapper.Map<CourseModel>(course);

                var isCourse = await _service.UpdateCourse(courseModel);

                return isCourse switch
                {
                    true => Ok(new BaseResponse(isCourse, ConstantMessage.Success)),
                    _ => Ok(new BaseResponse(isCourse, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

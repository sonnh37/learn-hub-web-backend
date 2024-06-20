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
    public class CourseController : Controller
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;

        public CourseController(ICourseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //[HttpPost("get-all-course")]
        //public async Task<IActionResult> GetAllCourse(PaginatedRequest<CourseRequest> paginatedRequest)
        //{
        //    try
        //    {
        //        var courses = await _service.GetAllCourse(paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy);

        //        return courses switch
        //        {
        //            null => Ok(new PaginatedResponseList<CourseModel>(
        //                null,
        //                ConstantMessage.NotFound)),
        //            not null => Ok(new PaginatedResponseList<CourseModel>(courses, ConstantMessage.Success, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy))
        //        };
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    };
        //}

        [HttpGet("get-course")]
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
                    null => Ok(new PaginatedResponse<CourseModel>(ConstantMessage.NotFound)),
                    not null => Ok(new PaginatedResponse<CourseModel>(ConstantMessage.Success, courseModel))
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add-new-course")]
        public async Task<IActionResult> AddCourse(CourseRequest course)
        {
            try
            {
                var isCourse = await _service.AddCourse(_mapper.Map<CourseModel>(course));

                return isCourse switch
                {
                    true => Ok(new BaseReponseBool(isCourse, ConstantMessage.Success)),
                    _ => Ok(new BaseReponseBool(isCourse, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("delete-course")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var isCourse = await _service.DeleteCourse(id);

                    return isCourse switch
                    {
                        true => Ok(new BaseReponseBool(isCourse, ConstantMessage.Success)),
                        _ => Ok(new BaseReponseBool(isCourse, ConstantMessage.Fail))
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

        [HttpPut("update-course")]
        public async Task<IActionResult> Update(CourseRequest course)
        {
            try
            {
                var courseModel = _mapper.Map<CourseModel>(course);

                var isCourse = await _service.UpdateCourse(courseModel);

                return isCourse switch
                {
                    true => Ok(new BaseReponseBool(isCourse, ConstantMessage.Success)),
                    _ => Ok(new BaseReponseBool(isCourse, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("get-all-course-by-provider")]
        //public async Task<IActionResult> GetAllPackageByProvider(Guid studentid)
        //{
        //    try
        //    {
        //        if (studentid == Guid.Empty)
        //        {
        //            return BadRequest("StudentId is empty");
        //        }

        //        var courseModels = await _service.GetAllCourseByProvider(studentid);

        //        return courseModels switch
        //        {
        //            not null => Ok(new BaseReponseList<CourseModel>(courseModels, ConstantMessage.Success)),
        //            null => Ok(new BaseReponseList<CourseModel>(null, ConstantMessage.NotFound, ConstantHttpStatus.NOT_FOUND))
        //        };

        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet("search-course-by-id-or-name")]
        //public async Task<IActionResult> SearchCourse(string course)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(course))
        //        {
        //            return BadRequest("StudentId is empty");
        //        }

        //        var courseModels = await _service.SearchCourse(course);

        //        return courseModels switch
        //        {
        //            not null => Ok(new BaseReponseList<CourseModel>(courseModels, ConstantMessage.Success)),
        //            null => Ok(new BaseReponseList<CourseModel>(null, ConstantMessage.NotFound, ConstantHttpStatus.NOT_FOUND))
        //        };
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}

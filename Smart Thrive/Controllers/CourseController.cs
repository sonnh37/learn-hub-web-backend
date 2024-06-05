using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Thrive.Mapping;
using Smart_Thrive.ResponseModel;
using SmartThrive.DataAccesss.Model.RequestModel;
using SWD.DataAccesss.Model;
using SWD.DataAccesss.Services.Interface;

namespace Smart_Thrive.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;

        public CourseController(ICourseService service , IMapper mapper ) 
        {
        _service = service;
        _mapper = mapper;
        }
        [HttpGet("get-course")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id is empty");
                }
                var s = await _service.GetCourse(id);
                if (s == null)
                {
                    return NotFound();
                }
                return Ok(s);

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
                var s = await _service.AddCourse(_mapper.Map<CourseModel>(course));
                if (s)
                {
                    return Ok(new BaseReponse()
                    {
                        Code = 200,
                        Data = s,
                        Message = "Succesfuly"

                    });
                }
                return BadRequest(s);

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
                    var sss = await _service.DeleteCourse(id);
                    if (sss)
                    {
                        return Ok("Succesfuly");
                    }
                    else
                    {
                        return BadRequest("Id is not exist or wrong");
                    }
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
                var s = _mapper.Map<CourseModel>(course);


                //      var exist = _service.GetOrder(order.Id);

                //      if (exist != null)
                //      {
                var sss = await _service.UpdateCourse(s);
                if (sss)
                {
                    return Ok(new BaseReponse()
                    {
                        Code = 200,
                        Data = sss,
                        Message = "Succesfuly"

                    });
                }
                else
                {
                    return BadRequest("Faild");
                }
                //         }
                //         else
                //        {
                //return BadRequest("It's not exist");
                //        }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-course-by-provider")]
        public async Task<IActionResult> GetAllPackageByStudent(Guid provideId)
        {
            try
            {


                /// nho check xem id co trong database khong o student
                if (provideId == Guid.Empty)
                {
                    return BadRequest("StudentId is empty");
                }
                var s = await _service.GetAllCoursesByProvider(provideId);
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

        [HttpGet("search-course-by-id-or-name")]
        public async Task<IActionResult> SearchCourse(string course)
        {
            try
            {


                /// nho check xem id co trong database khong o student
                if (string.IsNullOrEmpty(course))
                {
                    return BadRequest("StudentId is empty");
                }
                var s = await _service.SearchCourse(course);
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

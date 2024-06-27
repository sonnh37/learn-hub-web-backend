using AutoMapper;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.API.ResponseModel;
using SWD.SmartThrive.API.Tool.Constant;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;

namespace SWD.SmartThrive.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IMapper mapper, IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        [HttpPost("get-all-pagination")]
        public async Task<IActionResult> GetAllPagination(PaginatedRequest paginatedRequest)
        {
            try
            {
                var providers = await _studentService.GetAllPaginationWithOrder(paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy);
                long totalOrigin = await _studentService.GetTotalCount();

                return providers switch
                {
                    null => Ok(new PaginatedResponseList<StudentModel>(ConstantMessage.NotFound)),
                    not null => Ok(new PaginatedResponseList<StudentModel>(ConstantMessage.Success, providers, totalOrigin,
                                        paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id is empty");
                }
                var StudentModel = await _studentService.GetById(id);

                return StudentModel switch
                {
                    null => Ok(new PaginatedResponse<StudentModel>(ConstantMessage.NotFound)),
                    not null => Ok(new PaginatedResponse<StudentModel>(ConstantMessage.Success, StudentModel))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPost("search")]
        public async Task<IActionResult> GetAllUserSearch(PaginatedRequest<StudentSearchRequest> paginatedRequest)
        {
            try
            {
                var student = _mapper.Map<StudentModel>(paginatedRequest.Result);
                var students = await _studentService.Search(student, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy);

                return students.Item1 switch
                {
                    null => Ok(new PaginatedResponseList<StudentModel>(ConstantMessage.NotFound, students.Item1, students.Item2, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy)),
                    not null => Ok(new PaginatedResponseList<StudentModel>(ConstantMessage.Success, students.Item1, students.Item2, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy))
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(StudentRequest request)
        {
            try
            {
                bool isSuccess = await _studentService.Add(_mapper.Map<StudentModel>(request));
                return isSuccess switch
                {
                    true => Ok(new BaseResponse(isSuccess, ConstantMessage.Success)),
                    false => Ok(new BaseResponse(isSuccess, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(StudentRequest request)
        {
            try
            {
                bool isSuccess = await _studentService.Delete(_mapper.Map<StudentModel>(request));
                return isSuccess switch
                {
                    true => Ok(new BaseResponse(isSuccess, ConstantMessage.Success)),
                    false => Ok(new BaseResponse(isSuccess, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(StudentRequest request)
        {
            try
            {
                bool isSuccess = await _studentService.Update(_mapper.Map<StudentModel>(request));
                return isSuccess switch
                {
                    true => Ok(new BaseResponse(isSuccess, ConstantMessage.Success)),
                    false => Ok(new BaseResponse(isSuccess, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

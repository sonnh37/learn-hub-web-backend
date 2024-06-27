using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.API.ResponseModel;
using SWD.SmartThrive.API.Tool.Constant;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;
using SWD.SmartThrive.Services.Services.Service;

namespace SWD.SmartThrive.API.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService subjectService, IMapper mapper)
        {
            _service = subjectService;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var providers = await _service.GetAll();
                return providers switch
                {
                    null => Ok("not found"),
                    not null => Ok(providers)
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("get-all-pagination")]
        public async Task<IActionResult> GetAllPagination(PaginatedRequest paginatedRequest)
        {
            try
            {
                var subjects = await _service.GetAllPaginationWithOrder(paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy);
                long totalOrigin = await _service.GetTotalCount();

                return subjects switch
                {
                    null => Ok(new PaginatedResponseList<SubjectModel>(ConstantMessage.NotFound)),
                    not null => Ok(new PaginatedResponseList<SubjectModel>(ConstantMessage.Success, subjects, totalOrigin,
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
                var subject = await _service.GetById(id);

                return subject switch
                {
                    null => Ok(new PaginatedResponse<SubjectModel>(ConstantMessage.NotFound)),
                    not null => Ok(new PaginatedResponse<SubjectModel>(ConstantMessage.Success, subject))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpGet("get-by-categoryId/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(Guid categoryId)
        {
            try
            {
                if (categoryId == Guid.Empty)
                {
                    return BadRequest("Id is empty");
                }
                var subject = await _service.GetByCategoryId(categoryId);

                return subject switch
                {
                    null => Ok("No subject with given categoryId"),
                    not null => Ok(subject)
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPost("search")]
        public async Task<IActionResult> GetAllUserSearch(PaginatedRequest<SubjectSearchRequest> paginatedRequest)
        {
            try
            {
                var subject = _mapper.Map<SubjectModel>(paginatedRequest.Result);
                var subjects = await _service.Search(subject, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy);

                return subjects.Item1 switch
                {
                    null => Ok(new PaginatedResponseList<SubjectModel>(ConstantMessage.NotFound, subjects.Item1, subjects.Item2, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy)),
                    not null => Ok(new PaginatedResponseList<SubjectModel>(ConstantMessage.Success, subjects.Item1, subjects.Item2, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SubjectRequest request)
        {
            try
            {
                bool isSuccess = await _service.Add(_mapper.Map<SubjectModel>(request));
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
        public async Task<IActionResult> Delete(SubjectRequest request)
        {
            try
            {
                bool isSuccess = await _service.Delete(_mapper.Map<SubjectModel>(request));
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
        public async Task<IActionResult> Update(SubjectRequest request)
        {
            try
            {
                bool isSuccess = await _service.Update(_mapper.Map<SubjectModel>(request));
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

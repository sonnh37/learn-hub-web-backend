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
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _service;
        private readonly IMapper _mapper;

        public PackageController(IPackageService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //[HttpPost("get-all-package")]
        //public async Task<IActionResult> GetAllPackage(PaginatedRequest<PackageRequest> paginatedRequest)
        //{
        //    try
        //    {
        //        var packages = await _service.GetAllPackage(paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy);

        //        return packages switch
        //        {
        //            null => Ok(new PaginatedResponseList<PackageModel>(
        //                null,
        //                ConstantMessage.NotFound)),
        //            not null => Ok(new PaginatedResponseList<PackageModel>(packages, ConstantMessage.Success, paginatedRequest.PageNumber, paginatedRequest.PageSize, paginatedRequest.OrderBy))
        //        };
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    };
        //}

        [HttpGet("get-package")]
        public async Task<IActionResult> GetPackage(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Id is empty");
                }
                var packageModel = await _service.GetPackage(id);

                return packageModel switch
                {
                    null => Ok(new PaginatedResponse<PackageModel>(
                        null,
                        ConstantMessage.NotFound)),
                    not null => Ok(new PaginatedResponse<PackageModel>(packageModel, ConstantMessage.Success))
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add-new-package")]
        public async Task<IActionResult> AddPackage(PackageRequest package)
        {
            try
            {
                var isPackage = await _service.AddPackage(_mapper.Map<PackageModel>(package));

                return isPackage switch
                {
                    true => Ok(new BaseReponseBool(isPackage, ConstantMessage.Success)),
                    _ => Ok(new BaseReponseBool(isPackage, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("delete-package")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var isPackage = await _service.DeletePackage(id);

                    return isPackage switch
                    {
                        true => Ok(new BaseReponseBool(isPackage, ConstantMessage.Success)),
                        _ => Ok(new BaseReponseBool(isPackage, ConstantMessage.Fail))
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

        [HttpPut("update-package")]
        public async Task<IActionResult> Update(PackageRequest package)
        {
            try
            {
                var packageModel = _mapper.Map<PackageModel>(package);

                var isPackage = await _service.UpdatePackage(packageModel);

                return isPackage switch
                {
                    true => Ok(new BaseReponseBool(isPackage, ConstantMessage.Success)),
                    _ => Ok(new BaseReponseBool(isPackage, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("get-all-package-by-student")]
        //public async Task<IActionResult> GetAllPackageByStudent(Guid studentid)
        //{
        //    try
        //    {
        //        if (studentid == Guid.Empty)
        //        {
        //            return BadRequest("StudentId is empty");
        //        }

        //        var packageModels = await _service.GetAllPackageByStudent(studentid);

        //        return packageModels switch
        //        {
        //            not null => Ok(new BaseReponseList<PackageModel>(packageModels, ConstantMessage.Success)),
        //            null => Ok(new BaseReponseList<PackageModel>(null, ConstantMessage.NotFound, ConstantHttpStatus.NOT_FOUND))
        //        };

        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}

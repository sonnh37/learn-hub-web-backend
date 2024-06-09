using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SWD.SmartThrive.Services.Services.Interface;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.API.RequestModel;
using Smart_Thrive.Tool.Response;
using SWD.SmartThrive.API.Tool.Constant;

namespace Smart_Thrive.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _service;
        private readonly IMapper _mapper;

        public PackageController(IPackageService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

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
                    not null => Ok(AppResponse.GetResponseResult<PackageModel>(
                        packageModel,
                        ConstantMessage.NotFound,
                        ConstantHttpStatus.NOT_FOUND)),
                    null => Ok(AppResponse.GetResponseResult<PackageModel>(
                        packageModel,
                        ConstantMessage.Success))
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
                    true => Ok(AppResponse.GetResponseBool(isPackage, ConstantMessage.Success)),
                    _ => Ok(AppResponse.GetResponseBool(isPackage, ConstantMessage.Fail))
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
                        true => Ok(AppResponse.GetResponseBool(isPackage, ConstantMessage.Success)),
                        _ => Ok(AppResponse.GetResponseBool(isPackage, ConstantMessage.Fail))
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
                    true => Ok(AppResponse.GetResponseBool(isPackage, ConstantMessage.Success)),
                    _ => Ok(AppResponse.GetResponseBool(isPackage, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-package-by-student")]
        public async Task<IActionResult> GetAllPackageByStudent(Guid studentid)
        {
            try
            {
                if (studentid == Guid.Empty)
                {
                    return BadRequest("StudentId is empty");
                }

                var packageModels = await _service.GetAllPackagesByStudent(studentid);

                return packageModels switch
                {
                    not null => Ok(AppResponse.GetResponseResultList(packageModels.ToList(), ConstantMessage.Success)),
                    null => Ok(AppResponse.GetResponseResultList(packageModels.ToList(), ConstantMessage.NotFound, ConstantHttpStatus.NOT_FOUND))
                };

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

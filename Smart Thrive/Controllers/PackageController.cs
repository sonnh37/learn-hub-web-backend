using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Thrive.ResponseModel;
using SmartThrive.DataAccesss.Model.RequestModel;
using SmartThrive.DataAccesss.Services.Interface;
using SWD.DataAccesss.Model;
using SWD.DataAccesss.Services.Service;
using System.Runtime.Intrinsics.X86;

namespace Smart_Thrive.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _service;
        private readonly IMapper _mapper;

        public PackageController(IPackageService service , IMapper mapper) {
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
                var s = await _service.GetPackage(id);
                if(s == null)
                {
                    return NotFound();
                }
                return Ok(s);

            }catch (Exception ex) { 
            
            return BadRequest(ex.Message);
            };
        }

        [HttpPost("add-new-package")]
        public async Task<IActionResult> AddPackage(PackageRequest package)
        {
            try
            {
                var s = await _service.AddPackage(_mapper.Map<PackageModel>(package));
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

            }catch (Exception ex)
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
                    var sss = await _service.DeletePackage(id);
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

        [HttpPut("update-package")]
        public async Task<IActionResult> Update(PackageRequest package)
        {
            try
            {
                var s = _mapper.Map<PackageModel>(package);

                var exist = _service.GetPackage(package.Id);

                if (exist != null)
                {
                    var sss = await _service.UpdatePackage(s);
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
                }
                else
                {
                    return BadRequest("It's not exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-package-by-student")]
        public async Task<IActionResult> GetAllPackageByStudent(Guid studentid) {
            try
            {


                /// nho check xem id co trong database khong o student
                if (studentid == Guid.Empty)
                {
                    return BadRequest("StudentId is empty");
                }
                var s = await _service.GetAllPackagesByStudent(studentid);
                if(s == null)
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
            catch(Exception ex) {

                return BadRequest(ex.Message);
            }
        
        
        }
    }
}

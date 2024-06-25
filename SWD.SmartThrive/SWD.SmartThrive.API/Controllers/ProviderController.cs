using AutoMapper;
using Azure.Core;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.API.ResponseModel;
using SWD.SmartThrive.API.Tool.Constant;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;
using System.Drawing.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SWD.SmartThrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public ProviderController(IUserService userService, IMapper mapper, IProviderService providerService)
        {
            _userService = userService;
            _mapper = mapper;
            _providerService = providerService;
        }
        //[HttpPost]
        //public async Task<IActionResult> Add(ProviderRequest request)
        //{
        //    try
        //    {

        //    }catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpPut("delete")]
        public async Task<IActionResult> Delete(ProviderRequest request)
        {
            try
            {
                bool isSuccess = await _providerService.Delete(_mapper.Map<ProviderModel>(request));
                return isSuccess switch
                {
                    true => Ok(new BaseReponseBool(isSuccess, ConstantMessage.Success)),
                    false => Ok(new BaseReponseBool(isSuccess, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(ProviderRequest request)
        {
            try
            {
                bool isSuccess = await _providerService.Update(_mapper.Map<ProviderModel>(request));
                return isSuccess switch
                {
                    true => Ok(new BaseReponseBool(isSuccess, ConstantMessage.Success)),
                    false => Ok(new BaseReponseBool(isSuccess, ConstantMessage.Fail))
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        var providers = await _providerService.GetAll();
        //        return providers switch
        //        {
        //            null => Ok(new ),
        //            not null => Ok(new BaseReponseBool(isSuccess, ConstantMessage.Fail))
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        //[HttpGet]
        //public Task<IActionResult> GetById(Guid id)
        //{

        //}
        [HttpPost("import-excel-file")]
        public async Task<IActionResult> ImportExcelFile([FromForm] IFormFile file)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded!");
                }

                var uploadsFolder = $"{Directory.GetCurrentDirectory()}\\Uploads";

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, file.Name);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        bool isHeaderSkipped = false;
                        do
                        {
                            while (reader.Read())
                            {
                                if (!isHeaderSkipped)
                                {
                                    isHeaderSkipped = true;
                                    continue;
                                }
                                UserRequest u = new UserRequest();
                                u.Username = reader.GetValue(0).ToString();
                                u.Password = reader.GetValue(1).ToString();
                                u.FullName = reader.GetValue(2).ToString();
                                u.Email = reader.GetValue(3).ToString();
                                u.Address = reader.GetValue(4).ToString();
                                u.Gender = reader.GetValue(5).ToString();
                                u.Phone = reader.GetValue(6).ToString();
                                u.DOB = Convert.ToDateTime(reader.GetValue(7).ToString());
                                u.Status = true;
                                u.RoleId = Guid.Parse("13CDCAA1-614F-431E-BC5B-D7BFCB483EC7");
                                u.LocationId = Guid.Parse("458EF00A-24E2-4523-B8CC-1C28AEE2204F");

                                await _userService.AddUser(_mapper.Map<UserModel>(u));

                                ProviderRequest p = new ProviderRequest();
                                p.UserId = _mapper.Map<User>(_userService.GetUserByEmail(u.Email)).Id;
                                p.CompanyName = reader.GetValue(8).ToString();
                                p.Website = reader.GetValue(9).ToString();

                                await _providerService.Add(_mapper.Map<ProviderModel>(p));


                            }
                        } while (reader.NextResult());

                    }
                }

                return Ok("Inserted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

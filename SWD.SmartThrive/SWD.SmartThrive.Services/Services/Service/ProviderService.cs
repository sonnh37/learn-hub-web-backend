using AutoMapper;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Repositories.Repositories.UnitOfWork.Interface;
using SWD.SmartThrive.Services.Base;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.Services.Services.Service
{
    public class ProviderService : BaseService<Provider>, IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        public ProviderService(IMapper mapper, IUnitOfWork unitOfWork, IProviderRepository providerRepository) : base(mapper, unitOfWork)
        {
            _providerRepository = providerRepository;
        }

        public async Task<bool> Add(ProviderModel model)
        {
            try
            {
                return await _providerRepository.Add(_mapper.Map<Provider>(model));
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

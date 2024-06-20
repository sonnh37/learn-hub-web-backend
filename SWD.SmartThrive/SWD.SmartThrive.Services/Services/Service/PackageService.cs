using AutoMapper;
using Microsoft.AspNetCore.Http;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Repositories.Repositories.UnitOfWork.Interface;
using SWD.SmartThrive.Services.Base;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;

namespace SWD.SmartThrive.Services.Services.Service
{
    public class PackageService : BaseService<Package>, IPackageService
    {
        private readonly IPackageRepository _repository;

        public PackageService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _repository = unitOfWork.PackageRepository;
        }

        public async Task<bool> AddPackage(PackageModel PackageModel)
        {
            var Package = _mapper.Map<Package>(PackageModel);
            var package = await SetBaseEntityToCreateFunc(Package);
            return await _repository.Add(package);
        }

        public async Task<bool> UpdatePackage(PackageModel PackageModel)
        {
            var entity = await _repository.GetById(PackageModel.Id);
            if (entity == null)
            {
                return false;
            }

            var Package = _mapper.Map<Package>(PackageModel);
            var package = await SetBaseEntityToUpdateFunc(Package);
            return await _repository.Update(package);
        }

        public async Task<bool> DeletePackage(Guid id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return false;
            }

            var Package = _mapper.Map<Package>(entity);
            return await _repository.Delete(Package);
        }

        public async Task<List<PackageModel>> GetAllPackage()
        {
            var Packages = await _repository.GetAll();

            if (!Packages.Any())
            {
                return null;
            }

            return _mapper.Map<List<PackageModel>>(Packages);
        }

        public async Task<PackageModel> GetPackage(Guid id)
        {
            var Package = await _repository.GetById(id);

            if (Package == null)
            {
                return null;
            }

            return _mapper.Map<PackageModel>(Package);
        }
    }
}

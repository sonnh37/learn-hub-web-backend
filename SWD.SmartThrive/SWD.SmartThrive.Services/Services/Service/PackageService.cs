using AutoMapper;
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

        public PackageService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
            _repository = unitOfWork.PackageRepository;
        }

        public async Task<bool> AddPackage(PackageModel packageModel)
        {
            var package = await _repository.GetPackage(packageModel.Id);

            if (package != null)
            {
                return false;
            }

            var _package = _mapper.Map<Package>(packageModel);
            _package.Id = Guid.NewGuid();
            _repository.Add(_package);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
        }

        public async Task<bool> UpdatePackage(PackageModel packageModel)
        {
            var package = await _repository.GetPackage(packageModel.Id);

            if (package == null)
            {
                return false;
            }

            _mapper.Map(packageModel, package);
            _repository.Update(package);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
        }

        public async Task<bool> DeletePackage(Guid id)
        {
            var package = await _repository.GetPackage(id);

            if (package == null)
            {
                return false;
            }

            _repository.Delete(package);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
        }

        public async Task<List<PackageModel>> GetAllPackage()
        {
            var packages = await _repository.GetAllPackage();

            if (packages == null)
            {
                return null;
            }

            return _mapper.Map<List<PackageModel>>(packages);
        }

        public async Task<List<PackageModel>> GetAllPackageByStudent(Guid id)
        {
            
            var packages = await _repository.GetAllPackageByStudent(id);

            if (packages == null)
            {
                return null;
            }

            return _mapper.Map<List<PackageModel>>(packages);
        }

        public async Task<PackageModel> GetPackage(Guid id)
        {
            var package = await _repository.GetPackage(id);

            if (package == null)
            {
                return null;
            }

            return _mapper.Map<PackageModel>(package);
        }
    }
}

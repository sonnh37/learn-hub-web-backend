using AutoMapper;
using SmartThrive.DataAccesss.Services.Interface;
using ST.Entities.Data.Table;
using SWD.DataAccesss.Model;
using SWD.Entities.Repositories.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.DataAccesss.Services.Service
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _repository;
        private readonly IMapper _mapper;

        public PackageService(IPackageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<bool> AddPackage(PackageModel package)
        {
            var s = _mapper.Map<Package>(package);
            return await _repository.AddPackage(s);
        }

        public async Task<bool> DeletePackage(Guid id)
        {
            return await _repository.DeletePackage(id);
        }

        public async Task<IEnumerable<PackageModel>> GetAllPackages()
        {
            var s = await _repository.GetAllPackages();
            return _mapper.Map<IEnumerable<PackageModel>>(s);
        }

        public async Task<IEnumerable<PackageModel>> GetAllPackagesByStudent(Guid id)
        {
            var s = await _repository.GetAllPackagesByStudent(id);
            return _mapper.Map<IEnumerable<PackageModel>>(s);
        }

        public async Task<PackageModel> GetPackage(Guid id)
        {
            return _mapper.Map<PackageModel>(await _repository.GetPackage(id));
        }

        public async Task<bool> UpdatePackage(PackageModel package)
        {
            var s = _mapper.Map<Package>(package);
            return await _repository.UpdatePackage(s);
        }
    }
}

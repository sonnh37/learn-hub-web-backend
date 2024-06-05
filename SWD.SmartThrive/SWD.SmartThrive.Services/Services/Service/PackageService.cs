﻿using AutoMapper;
using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;

namespace SWD.SmartThrive.Services.Services.Service
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
            var s = await _repository.GetPackage(id);
            if (s != null)
            {
                s.IsDeleted = true;
                var order = await _repository.UpdatePackage(s);
                if (order)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<IEnumerable<PackageModel>> GetAllPackages()
        {
            var s = await _repository.GetAllPackages();
            return _mapper.Map<IEnumerable<PackageModel>>(s);
        }

        public async Task<IEnumerable<PackageModel>> GetAllPackagesByStudent(Guid id)
        {

            var s = await _repository.GetAllPackagesByStudent(id);
            if (s != null)
            {
                return _mapper.Map<IEnumerable<PackageModel>>(s);
            }
            return null;
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
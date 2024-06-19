﻿using SWD.SmartThrive.Services.Model;

namespace SWD.SmartThrive.Services.Services.Interface
{
    public interface IPackageService
    {
        Task<bool> AddPackage(PackageModel PackageModel);
        Task<bool> DeletePackage(Guid id);
        Task<List<PackageModel>> GetAllPackage();
        Task<PackageModel> GetPackage(Guid id);
        Task<bool> UpdatePackage(PackageModel PackageModel);
    }
}

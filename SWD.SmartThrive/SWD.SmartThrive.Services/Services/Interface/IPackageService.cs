using SWD.SmartThrive.Services.Model;

namespace SWD.SmartThrive.Services.Services.Interface
{
    public interface IPackageService
    {
        public Task<bool> AddPackage(PackageModel package);
        public Task<bool> UpdatePackage(PackageModel package);

        public Task<bool> DeletePackage(Guid id);

        public Task<PackageModel> GetPackage(Guid id);

        public Task<List<PackageModel>> GetAllPackagesByStudent(Guid id);

        public Task<List<PackageModel>> GetAllPackages();
    }
}

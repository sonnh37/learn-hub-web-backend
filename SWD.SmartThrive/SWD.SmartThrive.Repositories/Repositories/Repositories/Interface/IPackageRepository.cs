using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface IPackageRepository : IBaseRepository
    {
        public Task<bool> AddPackage(Package package);

        public Task<bool> UpdatePackage(Package package);

        public Task<bool> DeletePackage(Guid id);

        public Task<Package> GetPackage(Guid id);

        public Task<List<Package>> GetAllPackageByStudent(Guid id);

        public Task<List<Package>> GetAllPackage();

    }
}

using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface IPackageRepository : IBaseRepository<Package>
    {
        public Task<Package> GetPackage(Guid id);

        public Task<List<Package>> GetAllPackageByStudent(Guid id);

        public Task<List<Package>> GetAllPackage();


        public Task<List<Package>> SearchPackByIdOrName(string search);
    }
}

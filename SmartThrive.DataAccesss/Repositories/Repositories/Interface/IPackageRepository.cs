using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Repositories.Repositories.Interface
{
    public interface IPackageRepository
    {
        public Task<bool> AddPackage(Package package);
        public Task<bool> UpdatePackage(Package package);

        public Task<bool> DeletePackage(Guid id);

        public Task<Package> GetPackage(Guid id);

        public Task<IEnumerable<Package>> GetAllPackagesByStudent(Guid id);

        public Task<IEnumerable<Package>> GetAllPackages();

    }
}

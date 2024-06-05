using ST.Entities.Data.Table;
using SWD.DataAccesss.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services.Interface
{
    public interface IPackageService
    {
        public Task<bool> AddPackage(PackageModel package);
        public Task<bool> UpdatePackage(PackageModel package);

        public Task<bool> DeletePackage(Guid id);

        public Task<PackageModel> GetPackage(Guid id);

        public Task<IEnumerable<PackageModel>> GetAllPackagesByStudent(Guid id);

        public Task<IEnumerable<PackageModel>> GetAllPackages();
    }
}

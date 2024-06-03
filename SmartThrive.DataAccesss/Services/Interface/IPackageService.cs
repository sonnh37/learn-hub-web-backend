using SmartThrive.DataAccesss.Model.RequestModel;
using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services.Interface
{
    public interface IPackageService
    {
        public Task<bool> AddPackage(PackageRequest package);
        public Task<bool> UpdatePackage(PackageRequest package);

        public Task<bool> DeletePackage(Guid id);

        public Task<PackageRequest> GetPackage(Guid id);

        public Task<IEnumerable<PackageRequest>> GetAllPackagesByStudent(Guid id);

        public Task<IEnumerable<PackageRequest>> GetAllPackages();
    }
}

using SmartThrive.DataAccesss.Model.RequestModel;
using SmartThrive.DataAccesss.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services
{
    public class PackageService : IPackageService
    {
        Task<bool> IPackageService.AddPackage(PackageRequest package)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPackageService.DeletePackage(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<PackageRequest>> IPackageService.GetAllPackages()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<PackageRequest>> IPackageService.GetAllPackagesByStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<PackageRequest> IPackageService.GetPackage(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPackageService.UpdatePackage(PackageRequest package)
        {
            throw new NotImplementedException();
        }
    }
}

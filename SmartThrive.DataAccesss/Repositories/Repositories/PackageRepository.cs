using Microsoft.EntityFrameworkCore;
using SmartThrive.DataAccess.Repositories.Base;
using SmartThrive.DataAccess.Repositories.Repositories.Interface;
using SmartThrive.DataAccesss.Repositories.Repositories.Interface;
using ST.Entities.Data;
using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccess.Repositories.Repositories
{
    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
        private readonly STDbContext context;

        public PackageRepository(STDbContext _context) : base(_context)
        {
            this.context = _context;
        }

  

        public async Task<bool> AddPackage(Package package)
        {
          var ss = await base.Add(package);
            return ss;
        }

        public async Task<bool> DeletePackage(Guid id)
        {
            var delete = await base.Delete(id);
            return delete;
        }

        public async Task<IEnumerable<Package>> GetAllPackages()
        {
           var a = await base.GetAll();
            return a;
        }

        public async Task<IEnumerable<Package>> GetAllPackagesByStudent(Guid id)
        {
             var a = await context.Packages.Where(x => x.StudentId == id).ToListAsync();
            return a;
        }

        public async Task<Package> GetPackage(Guid id)
        {
            var g = await base.GetById(id);
            return g;
        }

        public async Task<bool> UpdatePackage(Package package)
        {
           var u = await base.Update(package);
            return u;
        }
    }
}

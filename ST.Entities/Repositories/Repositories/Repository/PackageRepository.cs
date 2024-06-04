using Microsoft.EntityFrameworkCore;
using SmartThrive.DataAccess.Repositories.Base;
using ST.Entities.Data;
using ST.Entities.Data.Table;
using SWD.Entities.Repositories.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Repositories.Repositories.Repository
{
    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
        private readonly STDbContext context;

        public PackageRepository(STDbContext _context) : base(_context)
        {
            context = _context;
        }



        public async Task<bool> AddPackage(Package package)
        {
            var ss = await Add(package);
            return ss;
        }

        public async Task<bool> DeletePackage(Guid id)
        {
            var delete = await Delete(id);
            return delete;
        }

        public async Task<IEnumerable<Package>> GetAllPackages()
        {
            var a = await GetAll();
            return a;
        }

        public async Task<IEnumerable<Package>> GetAllPackagesByStudent(Guid id)
        {
            var a = await context.Packages.Where(x => x.StudentId == id).ToListAsync();
            return a;
        }

        public async Task<Package> GetPackage(Guid id)
        {
            var g = await GetById(id);
            return g;
        }

        public async Task<bool> UpdatePackage(Package package)
        {
            var u = await Update(package);
            return u;
        }
    }
}

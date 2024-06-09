using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
        private readonly STDbContext _context;

        public PackageRepository(STDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<bool> AddPackage(Package package)
        {
            var entity = await base.GetById(package.Id);

            if (entity != null)
            {
                return false;
            }

            base.Add(package);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> DeletePackage(Guid id)
        {
            var entity = await base.GetById(id);

            if (entity == null)
            {
                return false;
            }
            base.Delete(entity);
            _context.SaveChanges();

            return true;
        }

        public async Task<List<Package>> GetAllPackages()
        {
            var packages = await GetAll();
            return packages;
        }

        public async Task<List<Package>> GetAllPackagesByStudent(Guid id)
        {
            var packages = base.GetQueryable(x => x.StudentId == id);
           
            if (packages.Any())
            {
                packages = packages.Where(x => !x.IsDeleted);
            }
            
            var results = await packages.Include(x => x.Student).ToListAsync();

            return results;
        }

        public async Task<Package> GetPackage(Guid id)
        {
            var g = await GetById(id);  
            return g;
        }

        public async Task<bool> UpdatePackage(Package package)
        {
            var entity = await base.GetById(package.Id);

            if (entity == null)
            {
                return false;
            }

            base.Update(entity);
            _context.SaveChanges();

            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using System.Linq;

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
            var queryable = await base.GetById(package.Id);

            if (!queryable.Any())
            {
                base.Add(package);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<bool> DeletePackage(Guid id)
        {
            var queryable = await base.GetById(id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();
                if (entity != null)
                {
                    entity.IsDeleted = true;
                    base.Update(entity);
                    _context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public async Task<List<Package>> GetAllPackage()
        {
            var queryable = await GetAll();

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var results = await queryable.ToListAsync();

                return results;
            }

            return null;
        }

        public async Task<List<Package>> GetAllPackageByStudent(Guid id)
        {
            var queryable = base.GetQueryable(x => x.StudentId == id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var results = await queryable.Include(x => x.Student).ToListAsync();

                return results;
            }

            return null;
        }

        public async Task<Package> GetPackage(Guid id)
        {
            var queryable = await base.GetById(id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();

                return entity;
            }

            return null;
        }

        public async Task<bool> UpdatePackage(Package package)
        {
            var queryable = await base.GetById(package.Id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();

                if (entity != null)
                {
                    _mapper.Map(package, entity);
                    base.Update(entity);

                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}

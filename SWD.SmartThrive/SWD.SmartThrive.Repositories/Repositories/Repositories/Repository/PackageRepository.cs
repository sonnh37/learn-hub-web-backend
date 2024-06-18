using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Entities;
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
                var results = await queryable.Include(x => x.Student)
                    .ToListAsync();

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

        public  async Task<List<Package>> SearchPackByIdOrName(string search)
        {
            var queryable =  base.GetQueryable(x => x.Id.Equals(search) || x.PackageName.StartsWith(search));
            if (queryable.Any())
            {
                queryable =  queryable.Where(x => x.IsDeleted!);
            }
            if (queryable.Any())
            {
                return await queryable.ToListAsync();
            }
            return null;
        }
    }
}

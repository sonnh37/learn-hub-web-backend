using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class CourseXPackageRepository : BaseRepository<CourseXPackage>, ICourseXPackageRepository
    {
        private readonly STDbContext context;

        public CourseXPackageRepository(STDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<bool> AddCourseToPackage(CourseXPackage newcourse)
        {
            await context.CourseXPackages.AddAsync(newcourse);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeleteCourseToPackage(CourseXPackage courseid)
        {
            throw new NotImplementedException();
        }
    }
}

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

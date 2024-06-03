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
    public class CourseXPackageRepository : BaseRepository<CourseXPackage>, ICourseXPackageRepository
    {
        private readonly STDbContext context;

        public CourseXPackageRepository(STDbContext _context) : base(_context)
        {
           this.context = _context;
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

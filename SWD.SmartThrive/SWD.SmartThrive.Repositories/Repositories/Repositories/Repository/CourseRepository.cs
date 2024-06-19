using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly STDbContext _context;

        public CourseRepository(STDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Course>> SearchCourse(string name)
        {
            var queryable = base.GetQueryable(x => x.CourseName.StartsWith(name) || x.Id.Equals(name));

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var results = await queryable.Include(x => x.Provider).ToListAsync();

                return results;
            }

            return null;
        }

    }
}

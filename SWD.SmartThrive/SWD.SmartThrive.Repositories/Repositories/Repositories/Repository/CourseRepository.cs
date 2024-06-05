using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly STDbContext context;

        public CourseRepository(STDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<bool> AddCourse(Course course)
        {
            var a = await Add(course);
            return a;
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            var d = await Delete(id);
            return d;
        }

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            var all = await GetAll();
            return all;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesByProvider(Guid id)
        {
            var allc = await context.Courses.Where(x => x.ProviderId == id).ToListAsync();
            return allc;
        }

        public async Task<Course> GetCourse(Guid id)
        {
            var course = await GetById(id);
            return course;
        }

        public async Task<IEnumerable<Course>> SearchCourse(string name)
        {
            var course = await context.Courses.Where(x => x.CourseName.StartsWith(name) || x.Id.Equals(name)).ToListAsync();
            return course;
        }

        public async Task<bool> UpdateCourse(Course course)
        {
            var update = await Update(course);
            return update;
        }
    }
}

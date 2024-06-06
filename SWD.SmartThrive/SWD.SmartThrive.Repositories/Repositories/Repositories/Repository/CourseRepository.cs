using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Table;
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

        public async Task<bool> AddCourse(Course course)
        {
            var entity = await base.GetById(course.Id);

            if (entity != null)
            {
                return false;
            }

            base.Add(course);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteCourse(Guid id)
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

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            var courses = await base.GetAll();
            return courses;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesByProvider(Guid id)
        {
            var courses = base.GetQueryable(x => x.ProviderId == id);

            if (courses.Any())
            {
                courses = courses.Where(x => !x.IsDeleted);
            }

            var results = await courses.Include(x => x.Provider).ToListAsync();

            return results;
        }

        public async Task<Course> GetCourse(Guid id)
        {
            var course = await base.GetById(id);
            return course;
        }

        public async Task<IEnumerable<Course>> SearchCourse(string name)
        {
            var course = await _context.Courses.Where(x => x.CourseName.StartsWith(name) || x.Id.Equals(name)).ToListAsync();
            return course;
        }

        public async Task<bool> UpdateCourse(Course course)
        {
            var entity = await base.GetById(course.Id);

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

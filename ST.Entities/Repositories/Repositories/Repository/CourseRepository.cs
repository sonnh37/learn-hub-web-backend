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

        public Task<IEnumerable<Course>> SearchCourse(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCourse(Course course)
        {
            var update = await Update(course);
            return update;
        }
    }
}

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
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly STDbContext context;

        public CourseRepository(STDbContext _context) : base(_context)
        {
            this.context = _context;
        }

        public async Task<bool> AddCourse(Course course)
        {
           var a = await base.Add(course);
            return a;
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            var d = await base.Delete(id);
            return d;
        }

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
           var all = await base.GetAll();
            return all;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesByProvider(Guid id)
        {
           var allc = await context.Courses.Where(x=>x.ProviderId == id).ToListAsync();
            return allc;    
        }

        public async Task<Course> GetCourse(Guid id)
        {
            var course = await base.GetById(id);
            return course;
        }

        public Task<IEnumerable<Course>> SearchCourse(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCourse(Course course)
        {
            var update = await base.Update(course);
            return update;
        }
    }
}

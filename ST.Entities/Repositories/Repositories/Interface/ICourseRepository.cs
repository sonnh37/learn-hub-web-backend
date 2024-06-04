using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.Entities.Repositories.Repositories.Interface
{
    public interface ICourseRepository
    {
        public Task<bool> AddCourse(Course course);
        public Task<bool> UpdateCourse(Course course);

        public Task<bool> DeleteCourse(Guid id);

        public Task<Course> GetCourse(Guid id);

        public Task<IEnumerable<Course>> GetAllCourse();
        public Task<IEnumerable<Course>> GetAllCoursesByProvider(Guid id);

        public Task<IEnumerable<Course>> SearchCourse(string name);
    }
}

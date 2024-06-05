using ST.Entities.Data.Table;
using SWD.DataAccesss.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.DataAccesss.Services.Interface
{
    public interface ICourseService
    {

        public Task<bool> AddCourse(CourseModel course);
        public Task<bool> UpdateCourse(CourseModel course);

        public Task<bool> DeleteCourse(Guid id);

        public Task<CourseModel> GetCourse(Guid id);

        public Task<IEnumerable<CourseModel>> GetAllCourse();
        public Task<IEnumerable<CourseModel>> GetAllCoursesByProvider(Guid id);

        public Task<IEnumerable<CourseModel>> SearchCourse(string name);
    }
}

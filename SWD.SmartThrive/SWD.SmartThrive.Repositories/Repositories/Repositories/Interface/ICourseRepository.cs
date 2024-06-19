using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        public Task<List<Course>> SearchCourse(string name);
    }
}

using SWD.SmartThrive.Repositories.Data.Table;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface ICourseRepository
    {
        public Task<bool> AddCourse(Course course);

        public Task<bool> UpdateCourse(Course course);

        public Task<bool> DeleteCourse(Guid id);

        public Task<Course> GetCourse(Guid id);

        public Task<List<Course>> GetAllCourse();

        public Task<List<Course>> GetAllCourseByProvider(Guid id);

        public Task<List<Course>> SearchCourse(string name);
    }
}

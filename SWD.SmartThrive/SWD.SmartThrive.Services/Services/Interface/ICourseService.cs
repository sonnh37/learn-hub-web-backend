using SWD.SmartThrive.Services.Model;

namespace SWD.SmartThrive.Services.Services.Interface
{
    public interface ICourseService
    {
        Task<bool> AddCourse(CourseModel CourseModel);
        Task<bool> DeleteCourse(Guid id);
        Task<List<CourseModel>> GetAllCourse();
        Task<CourseModel> GetCourse(Guid id);
        Task<bool> UpdateCourse(CourseModel CourseModel);
        public Task<List<CourseModel>?> GetAllPagination(int pageNumber, int pageSize, string sortField, int sortOrder);

        public Task<(List<CourseModel>?, long)> GetAllCourseSearch(CourseModel courseModel, int pageNumber, int pageSize, string sortField, int sortOrder);

        public Task<long> GetTotalCount();

    }
}

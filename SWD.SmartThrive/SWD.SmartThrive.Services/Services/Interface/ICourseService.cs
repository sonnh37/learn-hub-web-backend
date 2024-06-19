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
    }
}

using SWD.SmartThrive.Repositories.Data.Table;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface ICourseXPackageRepository
    {
        public Task<bool> AddCourseToPackage(CourseXPackage coursex);

        public Task<bool> DeleteCourseToPackage(CourseXPackage courseid);


    }
}
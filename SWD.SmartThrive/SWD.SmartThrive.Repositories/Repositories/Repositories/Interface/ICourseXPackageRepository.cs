using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface ICourseXPackageRepository : IBaseRepository
    {
        public Task<bool> AddCourseToPackage(CourseXPackage coursex);

        public Task<bool> DeleteCourseToPackage(CourseXPackage courseid);


    }
}
using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.Entities.Repositories.Repositories.Interface
{
    public interface ICourseXPackageRepository
    {
        public Task<bool> AddCourseToPackage(CourseXPackage coursex);

        public Task<bool> DeleteCourseToPackage(CourseXPackage courseid);


    }
}
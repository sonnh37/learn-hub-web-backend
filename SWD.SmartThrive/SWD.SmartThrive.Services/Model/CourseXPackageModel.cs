using SWD.SmartThrive.Repositories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.Services.Model
{
    public class CourseXPackageModel : BaseModel
    {
        public Guid CourseId { get; set; }

        public Guid PackageId { get; set; }

        public CourseModel? Course { get; set; }

        public PackageModel? Package { get; set; }
    }
}

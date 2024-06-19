using SWD.SmartThrive.Repositories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.Services.Model
{
    public class LocationModel : BaseModel
    {
        public string City { get; set; }

        public string District { get; set; }

        public string Ward { get; set; }

        public IList<UserModel>? Users { get; set; }

        public IList<CourseModel>? Courses { get; set; }
    }
}

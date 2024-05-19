using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data.Table
{
    [Table("CourseXPackage")]
    public class CourseXPackage
    {
        public string CourseId { get; set; }
        public Course Course { get; set; }

        public string PackageId { get; set; }
        public Package Package { get; set; }
    }
}

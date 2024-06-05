using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.SmartThrive.Repositories.Data.Table
{
    [Table("CourseXPackage")]
    public class CourseXPackage
    {
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }

        public Guid PackageId { get; set; }
        public Package? Package { get; set; }
    }
}

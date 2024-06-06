using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.SmartThrive.Repositories.Data.Table
{
    [Table("CourseXPackage")]
    public class CourseXPackage : BaseEntity
    {
        public Guid CourseId { get; set; }

        public Guid PackageId { get; set; }

        public virtual Course? Course { get; set; }

        public virtual Package? Package { get; set; }
    }
}

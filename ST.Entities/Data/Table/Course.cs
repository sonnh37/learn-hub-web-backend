using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data.Table
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public string Id { get; set; }

        public string CourseName { get; set; }

        public string SubjectId { get; set; }

        public string ProviderId { get; set; }
        public Guid? Code { get; set; }
        public string? CreateBy { get; set; }

        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? DOB { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public int? TotalSlot { get; set; }


        public bool? IsApproved { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Subject Subject { get; set; }    
        public virtual ICollection<Session> Sessions { get; set; }

        public virtual ICollection<CourseXPackage> CourseXPackages { get; set; }
    }
}

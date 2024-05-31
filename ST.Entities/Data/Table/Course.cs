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
        public Guid Id { get; set; }

        public Guid SubjectId { get; set; }

        public Guid? ProviderId { get; set; }

        public Guid LocationId { get; set; }
        public Guid? Code { get; set; }

        public string? CourseName { get; set; }
        public Guid? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }
        [Required]
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? LastUpdatedBy { get; set; }
        public DateTime? DOB { get; set; }
        
        public string? Description { get; set; }
        public Decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public int? Sold_product { get; set; }

        public int? TotalSlot { get; set; }


        public bool? IsApproved { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }


        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual Location Location { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Provider? Provider { get; set; }
        public virtual ICollection<Session>? Sessions { get; set; }

        public virtual ICollection<CourseXPackage>? CourseXPackages { get; set; }
    }
}

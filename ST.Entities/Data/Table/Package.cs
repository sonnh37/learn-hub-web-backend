using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data.Table
{
    [Table("Package")]
    public class Package
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public string PackageName { get; set; }

        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }

        public int? QuantityCourse { get; set; }

        public Decimal TotalPrice { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }
        [Required]
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
     
        public bool? IsActive { get; set; }

        public virtual Student? Student { get; set; }
        public virtual ICollection<CourseXPackage>? CourseXPackages { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}

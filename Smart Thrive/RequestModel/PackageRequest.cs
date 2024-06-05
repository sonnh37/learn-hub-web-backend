using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Model.RequestModel
{
    public  class PackageRequest
    {
        public Guid? StudentId { get; set; }

        public string PackageName { get; set; }

        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }

        public int? QuantityCourse { get; set; }

        public Decimal TotalPrice { get; set; }

        public string? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }
        [Required]
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public bool? IsActive { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.API.RequestModel
{
    public class PackageRequest
    {
        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }

        public string PackageName { get; set; }

        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }

        public int? QuantityCourse { get; set; }

        public decimal TotalPrice { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        [Required]
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public bool? IsActive { get; set; }

    }
}

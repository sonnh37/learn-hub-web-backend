using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.Entities.Repositories.Repositories.Model
{
    public class OrderByStudent
    {
        public Guid StudentId { get; set; }
        public Guid Id { get; set; }

        public Guid PackageId { get; set; }

        public string? PackageName { get; set; }
        public string? PaymentMethod { get; set; }
        public int? Amount { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public string? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }
        [Required]
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Model
{
    public class SortFieldStudent
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
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        [Required]
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}

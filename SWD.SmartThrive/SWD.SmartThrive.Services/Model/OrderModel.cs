using System.ComponentModel.DataAnnotations;

namespace SWD.SmartThrive.Services.Model
{
    public class OrderModel
    {
        public Guid? PackageId { get; set; }

        public string? PaymentMethod { get; set; }

        public int? Amount { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? Description { get; set; }

        public bool? Status { get; set; }

        public Guid Id { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        
        public DateTime? LastUpdatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

    }
}

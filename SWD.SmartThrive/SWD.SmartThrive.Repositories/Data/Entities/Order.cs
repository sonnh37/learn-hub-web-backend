using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.SmartThrive.Repositories.Data.Entities
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        public Guid? PackageId { get; set; }

        public string? PaymentMethod { get; set; }

        public int? Amount { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? Description { get; set; }

        public bool? Status { get; set; }

        public virtual Package? Package { get; set; }

    }
}

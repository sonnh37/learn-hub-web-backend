using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data.Table
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public string Id { get; set; }

        public string StudentId { get; set; }

        public string PackagedId { get; set; }
        public string? PaymentMethod { get; set; }
        public int? Amount { get; set; }
        public Decimal? TotalPrice { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public string? CreateBy { get; set; }

        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

      //  public virtual Student Student { get; set; }
        public virtual Package Package { get; set; }

    }
}

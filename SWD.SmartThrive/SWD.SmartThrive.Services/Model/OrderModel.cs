using SWD.SmartThrive.Repositories.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SWD.SmartThrive.Services.Model
{
    public class OrderModel : BaseModel
    {
        public Guid? PackageId { get; set; }

        public string? PaymentMethod { get; set; }

        public int? Amount { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? Description { get; set; }

        public bool? Status { get; set; }

        public PackageModel? Package { get; set; }

    }
}

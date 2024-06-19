using SWD.SmartThrive.Repositories.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SWD.SmartThrive.Services.Model
{
    public class PackageModel : BaseModel
    {
        public Guid? StudentId { get; set; }

        public string PackageName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? QuantityCourse { get; set; }

        public decimal TotalPrice { get; set; }

        public bool? IsActive { get; set; }

        public StudentModel? Student { get; set; }

        //public IList<CourseXPackage>? CourseXPackages { get; set; }

        public IList<OrderModel>? Orders { get; set; }
    }
}

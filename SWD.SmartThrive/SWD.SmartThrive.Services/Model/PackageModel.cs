using SWD.SmartThrive.Repositories.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SWD.SmartThrive.Services.Model
{
    public class PackageModel
    {
        public Guid? StudentId { get; set; }

        public string PackageName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? QuantityCourse { get; set; }

        public decimal TotalPrice { get; set; }

        public Guid Id { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        public StudentModel? Student { get; set; }

        //public IList<CourseXPackage>? CourseXPackages { get; set; }

        public IList<OrderModel>? Orders { get; set; }
    }
}

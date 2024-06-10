using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.SmartThrive.Repositories.Data.Entities
{
    [Table("Student")]
    public class Student : BaseEntity
    {
        public Guid UserId { get; set; }

        public string? StudentName { get; set; }

        public string? Gender { get; set; }

        public DateTime? DOB { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Package>? Packages { get; set; }

        //    public virtual ICollection<Order> Orders { get; set; }
    }
}

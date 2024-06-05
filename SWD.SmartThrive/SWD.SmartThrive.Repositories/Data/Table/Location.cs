using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.SmartThrive.Repositories.Data.Table
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public Guid Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public bool isDeleted { get; set; }

        public virtual ICollection<User>? Users { get; set; }

        public virtual ICollection<Course>? Courses { get; set; }
    }
}

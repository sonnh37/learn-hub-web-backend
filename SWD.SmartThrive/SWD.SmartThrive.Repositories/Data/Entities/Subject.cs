using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.SmartThrive.Repositories.Data.Entities
{
    [Table("Subject")]
    public class Subject : BaseEntity
    {
        public string SubjectName { get; set; }

        public Guid? CategoryID { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Course>? Courses { get; set; }
    }
}

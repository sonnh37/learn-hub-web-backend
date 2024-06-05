using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.SmartThrive.Repositories.Data.Table
{

    [Table("Category")]
    public class Category
    {

        [Key]
        public Guid Id { get; set; }

        public string CategorytName { get; set; }
        public string? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }
        [Required]
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Subject>? Subjects { get; set; }

    }
}

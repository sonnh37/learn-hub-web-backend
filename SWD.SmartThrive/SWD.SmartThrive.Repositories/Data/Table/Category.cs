using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.SmartThrive.Repositories.Data.Table
{

    [Table("Category")]
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public virtual ICollection<Subject>? Subjects { get; set; }

    }
}

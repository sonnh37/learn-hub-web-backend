using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.SmartThrive.Repositories.Data.Table
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        public string? RoleName { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}


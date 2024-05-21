using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data.Table
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid Id{ get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
      
        public bool Status { get; set; }
        public Guid RoleID { get; set; }
        public Guid LocationID { get; set; }
        public virtual Role Role { get; set; } // khai bao de tu dong tai bien cua role xuong
        public virtual Location Location { get; set; } // khai bao de tu dong tai bien cua role xuong

        public virtual Provider Provider { get; set; }

        public virtual ICollection<Student> Students { get; set; }
     


    }
}

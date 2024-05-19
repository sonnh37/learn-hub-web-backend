using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data.Table
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public string Id { get; set; }

        public string? StudentName { get; set; }
        public string? CreateBy { get; set; }
      
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? UserId { get; set; }
        public string? Gender { get; set; }

        public DateTime? DOB { get; set; }
        public bool IsDeleted { get; set; }

       
    }
}

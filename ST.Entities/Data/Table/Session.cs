using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data.Table
{
    [Table("Session")]
    public class Session
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string SessionName { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LearnDate { get; set; }
        public string? CreateBy { get; set; }

        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
    
        public bool IsDeleted { get; set; }
        public virtual Course Course { get; set; }
    }
}

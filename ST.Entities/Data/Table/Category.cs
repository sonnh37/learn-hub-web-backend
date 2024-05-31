using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data.Table
{

    [Table("Category")]
    public class Category
    {
       
            [Key]
            public Guid Id { get; set; }

            public string CategorytName { get; set; }
            public Guid? CreateBy { get; set; }

            public DateTime? CreateDate { get; set; }
            [Required]
            public DateTime? LastUpdatedDate { get; set; }
            public Guid? LastUpdatedBy { get; set; }
            public bool IsDeleted { get; set; }

        public virtual ICollection<Subject>? Subjects { get; set; }
        
    }
}

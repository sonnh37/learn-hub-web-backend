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
            public string Id { get; set; }

            public string CategorytName { get; set; }
            public string StudentID { get; set; }
            public string? CreateBy { get; set; }

            public DateTime CreateDate { get; set; }
            [Required]
            public DateTime LastUpdatedDate { get; set; }
            public string? LastUpdatedBy { get; set; }
            public bool IsDeleted { get; set; }
        
    }
}

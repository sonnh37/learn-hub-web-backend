using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data.Table
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public Guid Id { get; set; }  
        public string Country { get; set; }

        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public bool isDeleted { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}

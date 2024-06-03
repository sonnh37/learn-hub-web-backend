using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data.Table
{
    public class Provider 
    {

       public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public virtual User? User { get; set; }
        // Các thuộc tính khác
        public virtual ICollection<Course>? Courses { get; set; }
    }
}

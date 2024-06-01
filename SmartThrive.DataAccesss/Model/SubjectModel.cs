using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Model
{
    public class SubjectModel
    {
        public Guid Id { get; set; }

        public string SubjectName { get; set; }
        public Guid CategoryID { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}

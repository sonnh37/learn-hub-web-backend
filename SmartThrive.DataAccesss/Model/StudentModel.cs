using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Model
{
    public class StudentModel
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? StudentName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}

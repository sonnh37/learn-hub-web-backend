using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.SmartThrive.Repositories.Data.Entities
{
    [Table("Session")]
    public class Session : BaseEntity
    {
        public Guid CourseId { get; set; }

        public string SessionName { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? LearnDate { get; set; }

        public virtual Course? Course { get; set; }
    }
}

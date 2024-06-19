using SWD.SmartThrive.Repositories.Data.Entities;

namespace SWD.SmartThrive.Services.Model
{
    public class SessionModel : BaseModel
    {
        public Guid CourseId { get; set; }

        public string SessionName { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? LearnDate { get; set; }

        public CourseModel? Course { get; set; }
    }
}

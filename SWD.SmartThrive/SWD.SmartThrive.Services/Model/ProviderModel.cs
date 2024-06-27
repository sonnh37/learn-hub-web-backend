using SWD.SmartThrive.Repositories.Data.Entities;

namespace SWD.SmartThrive.Services.Model
{
    public class ProviderModel : BaseModel
    {
        public Guid? UserId { get; set; }

        public string? CompanyName { get; set; }

        public string? Website { get; set; }

        public UserModel? User { get; set; }

        public IList<CourseModel>? Courses { get; set; }
    }
}

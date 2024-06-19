using SWD.SmartThrive.Repositories.Data.Entities;

namespace SWD.SmartThrive.Services.Model
{
    public class StudentModel : BaseModel
    {
        public Guid UserId { get; set; }

        public string? StudentName { get; set; }

        public string? Gender { get; set; }

        public DateTime? DOB { get; set; }

        public UserModel? User { get; set; }

        public IList<PackageModel>? Packages { get; set; }
    }
}

using SWD.SmartThrive.Repositories.Data.Entities;

namespace SWD.SmartThrive.Services.Model
{
    public class SubjectModel : BaseModel
    {
        public string SubjectName { get; set; }

        public Guid? CategoryId { get; set; }

        public CategoryModel? Category { get; set; }

        public IList<CourseModel>? Courses { get; set; }
    }
}

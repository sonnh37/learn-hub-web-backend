using SWD.SmartThrive.Repositories.Data.Entities;

namespace SWD.SmartThrive.Services.Model
{
    public class CategoryModel : BaseModel
    {
        public string CategoryName { get; set; }

        public IList<SubjectModel>? Subjects { get; set; }
    }
}

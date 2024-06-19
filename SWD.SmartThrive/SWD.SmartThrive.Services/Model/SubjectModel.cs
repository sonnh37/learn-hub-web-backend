namespace SWD.SmartThrive.Services.Model
{
    public class SubjectModel : BaseModel
    {
        public string SubjectName { get; set; }

        public Guid CategoryId { get; set; }
    }
}

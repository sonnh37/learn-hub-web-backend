namespace SWD.SmartThrive.Services.Model
{
    public class SessionModel
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string SessionName { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LearnDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}

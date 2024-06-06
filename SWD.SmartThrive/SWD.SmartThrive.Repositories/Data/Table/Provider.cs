namespace SWD.SmartThrive.Repositories.Data.Table
{
    public class Provider : BaseEntity
    {
        public Guid UserId { get; set; }

        public string CompanyName { get; set; }

        public string Website { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Course>? Courses { get; set; }

    }
}

namespace SWD.SmartThrive.API.SearchRequest
{
    public class StudentSearchRequest
    {
        public Guid? UserId { get; set; }

        public string? StudentName { get; set; }

        public string? Gender { get; set; }

        public DateTime? DOB { get; set; }
    }
}

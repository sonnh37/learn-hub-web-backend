namespace SWD.SmartThrive.API.RequestModel
{
    public class StudentRequest : BaseRequest
    {
        public Guid? UserId { get; set; }

        public string? StudentName { get; set; }

        public string? Gender { get; set; }

        public DateTime? DOB { get; set; }
    }
}

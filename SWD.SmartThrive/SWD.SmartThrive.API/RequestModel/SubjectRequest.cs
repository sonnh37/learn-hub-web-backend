namespace SWD.SmartThrive.API.RequestModel
{
    public class SubjectRequest : BaseRequest
    {
        public string SubjectName { get; set; }

        public Guid? CategoryId { get; set; }
    }
}

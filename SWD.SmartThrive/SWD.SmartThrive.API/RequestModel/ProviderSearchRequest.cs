namespace SWD.SmartThrive.API.RequestModel
{
    public class ProviderSearchRequest
    {
        public Guid? UserId { get; set; }

        public string? CompanyName { get; set; }

        public string? Website { get; set; }
    }
}

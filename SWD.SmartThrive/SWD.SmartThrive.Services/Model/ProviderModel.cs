namespace SWD.SmartThrive.Services.Model
{
    public class ProviderModel : BaseModel
    {
        public Guid UserId { get; set; }

        public string CompanyName { get; set; }

        public string Website { get; set; }
    }
}

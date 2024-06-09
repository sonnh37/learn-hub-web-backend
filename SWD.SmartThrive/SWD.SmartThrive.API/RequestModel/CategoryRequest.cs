namespace SWD.SmartThrive.API.RequestModel
{
    public class CategoryRequest
    {
        public Guid Id { get; set; }

        public string CategorytName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}

namespace SWD.SmartThrive.API.SearchRequest
{
    public class UserSearchRequest
    {
        public string? Username { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public DateTime? DOB { get; set; }

        public string? Address { get; set; }

        public string? Gender { get; set; }

        public string? Phone { get; set; }

        public bool? Status { get; set; }

        public Guid? RoleId { get; set; }

        public Guid? LocationId { get; set; }
    }
}

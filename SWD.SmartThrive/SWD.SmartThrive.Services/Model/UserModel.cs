namespace SWD.SmartThrive.Services.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public bool Status { get; set; }
        public Guid RoleID { get; set; }
        public Guid LocationID { get; set; }
    }
}

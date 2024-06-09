﻿namespace SWD.SmartThrive.API.RequestModel
{
    public class StudentRequest
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? StudentName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
